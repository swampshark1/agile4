using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public string keyID; // Unique identifier for the key

    private void Start()
    {
        // Check if the key has already been collected
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null && player.HasKey(keyID))
        {
            Destroy(gameObject); // Destroy the key if it has already been collected
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.AddKey(keyID);
                Destroy(gameObject); // Remove the key from the scene
            }
        }
    }
}
