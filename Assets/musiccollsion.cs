using UnityEngine;

public class EnemyBattleMusicTrigger : MonoBehaviour
{
    public AudioClip battleMusic;  // Reference to the battle music clip
    private AudioSource audioSource;  // AudioSource component to play the music

    void Start()
    {
        // Ensure the AudioSource is attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // If no AudioSource component is found, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the battle music
            if (battleMusic != null)
            {
                audioSource.clip = battleMusic;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Battle music not assigned!");
            }
        }
    }
}
