using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming left mouse button is used for shooting
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 forwardDirection = transform.forward;
        Vector3 startPosition = transform.position;

        // Debug line to visualize the raycast
        Debug.DrawRay(startPosition, forwardDirection * range, Color.red, 2f);

        if (Physics.Raycast(startPosition, forwardDirection, out hit, range))
        {
            Debug.Log("Hit: " + hit.transform.name); // Log the name of the object hit

            Enemy targetEnemy = hit.transform.GetComponent<Enemy>();
            if (targetEnemy != null)
            {
                Debug.Log("Dealing damage to: " + hit.transform.name);
                targetEnemy.TakeDamage(damage);
            }
            else
            {
                Debug.Log("No Enemy component found on: " + hit.transform.name);
            }
        }
        else
        {
            Debug.Log("No hit detected");
        }
    }
}
