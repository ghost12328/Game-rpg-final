using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class ExitTrigger : MonoBehaviour
{
    public string sceneName;  // The name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with the exit
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the exit. Loading next scene...");

            // Load the specified scene
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogWarning("Scene name not set for ExitTrigger.");
            }
        }
    }
}
