using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;
    
    public bool isDead;
    private void Start()
    {
        currentHealth = maxHealth; // Set current health to max at the start
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);

        // Trigger hit animation if still alive
        if (currentHealth > 0)
        {
            animator.SetTrigger("Damage");
        }
        // Trigger death animation if health drops to 0 or below
        else
        {
            isDead = true;
            Die();
        }
    }

    // Handle death
    void Die()
    {
        Debug.Log("Player died");
        animator.SetTrigger("Dead");
        // Optionally disable further interactions or movement here
        // Disable player controls or deactivate the object, etc.
    }
}
