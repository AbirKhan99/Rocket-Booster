using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float Thrust = 10f;
    [SerializeField] float RotationThrust = 1f;
    Rigidbody rb;
    AudioSource audioSource;
   void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource= GetComponent<AudioSource>();
        

    }

   
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    void ProcessThrust()
{
    if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
    {
        rb.AddRelativeForce(Vector3.up * Thrust * Time.deltaTime);

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    else
    {
        audioSource.Stop();
    }
}

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            ApplyRotation(-RotationThrust);
            Debug.Log("d");
        }

        else if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(RotationThrust);
            Debug.Log("A");
        }
    }

    void ApplyRotation(float rotationthisframe)
    {
        rb.freezeRotation= true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationthisframe);
        rb.freezeRotation = false;
    }
}
