using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public string enemyID;
    public int health = 100;
    public bool isDead = false;
    [HideInInspector] public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            // Error handling without Debug.Log
            throw new System.Exception("Animator component not found on " + gameObject.name);
        }

        // Temporarily bypass LoadState to check default behavior
        isDead = false;
        health = 100;

        // Set the initial state directly
        SetState(isDead);
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;  // Prevent re-triggering of death logic if already dead

        health = 0;
        isDead = true;

        animator.SetBool("IsDead", true);

        // Start a coroutine to wait for the animation to finish before disabling the enemy's functionality
        StartCoroutine(DisableAfterAnimation());
    }

    IEnumerator DisableAfterAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        DisableEnemy();
    }

    public void DisableEnemy()
    {
        var enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.enabled = false;
        }

        var enemyCollider = GetComponent<Collider>();
        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        // The enemy remains in the scene, but without movement and collider functionality
    }

    public void SetState(bool dead)
    {
        isDead = dead;

        if (isDead)
        {
            health = 0;
            animator.SetBool("IsDead", true);
            DisableEnemy();
        }
        else
        {
            animator.SetBool("IsDead", false);
            var enemyMovement = GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.enabled = true;
            }

            var enemyCollider = GetComponent<Collider>();
            if (enemyCollider != null)
            {
                enemyCollider.enabled = true;
            }
        }
    }
}
