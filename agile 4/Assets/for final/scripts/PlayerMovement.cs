using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    private Rigidbody rb;
    private HashSet<string> collectedKeys = new HashSet<string>(); // Collection to store key identifiers

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Get input for movement and rotation
        float moveInput = Input.GetAxis("Vertical");
        float rotationInput = Input.GetAxis("Horizontal");

        // Move the player forward and backward using Rigidbody
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        // Rotate the player left and right
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotation));
    }

    public void AddKey(string keyID)
    {
        if (!collectedKeys.Contains(keyID))
        {
            collectedKeys.Add(keyID); // Add key to the collection
            Debug.Log("Key " + keyID + " added to inventory.");
        }
    }

    public bool HasKey(string keyID)
    {
        return collectedKeys.Contains(keyID); // Check if the player has the specific key
    }

    public List<string> GetCollectedKeys()
    {
        return new List<string>(collectedKeys); // Get a list of collected keys
    }

    public void SetCollectedKeys(List<string> keys)
    {
        collectedKeys = new HashSet<string>(keys); // Set the collected keys from a list
    }
}
