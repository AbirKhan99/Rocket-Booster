using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandles : MonoBehaviour
{
    [SerializeField] float DelayInLoading = 1f;

    Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Respawn":
                Debug.Log("This is the starting point");
                break;

            case "Finish":
                Debug.Log("This is the end point");
                StartSuccessSequence();
                break;

            default:
                Debug.Log("YOU BLEW UP");
                StartCrashsequence();
                break;
        }
    }

    void StartCrashsequence()
    {
        movement.enabled = false;

        Invoke("ReloadLevel", DelayInLoading);
    }

    void StartSuccessSequence()
    {
        movement.enabled = false;

        Invoke("NextLevel", DelayInLoading);
    }

    void NextLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextlevel = CurrentSceneIndex + 1;

        if (nextlevel == SceneManager.sceneCountInBuildSettings)
        {
            nextlevel = 0;
        }

        SceneManager.LoadScene(nextlevel);
    }

    void ReloadLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(CurrentSceneIndex);
    }
}