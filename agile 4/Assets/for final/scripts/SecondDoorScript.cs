using UnityEngine;

public class SecondDoorScript : MonoBehaviour
{
    private Animator animator;
    public string doorID; // Unique identifier for the door
    public string requiredKeyID; // Unique identifier for the key required to open this door
    public bool isOpen = false; // Track the state of the door
    private bool isPlayerNearby = false; // Track if the player is near the door
    private PlayerMovement player;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (isOpen)
        {
            animator.SetBool("Open", true); // Ensure the door is open if the state is saved as open
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            TryOpenDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();
            if (player != null && player.HasKey(requiredKeyID))
            {
                isPlayerNearby = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            player = null;
        }
    }

    private void TryOpenDoor()
    {
        if (player != null && player.HasKey(requiredKeyID))
        {
            animator.SetBool("Open", true); // Trigger the 'Open' animation
        }
    }

    // This method will be called at the end of the animation
    public void OnAnimationComplete()
    {
        SetState(true); // Set the door as open
        animator.SetBool("Open", false); // Reset the animation parameter if needed
    }

    public void SetState(bool open)
    {
        isOpen = open;
        // Update door visuals or behavior based on the open state
        // Example: if you have different animations or states, handle them here
        if (open)
        {
            // Handle door open state (e.g., disable collision, play sound, etc.)
        }
        else
        {
            // Handle door closed state
        }
    }
}
