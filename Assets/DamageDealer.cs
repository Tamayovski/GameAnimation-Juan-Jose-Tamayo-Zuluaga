using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnCollisionEnter(Collision collision)
    {
        HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        if (healthSystem != null)
        {
            healthSystem.TakeDamage(damageAmount); // Apply damage on collision
        }
    }
}
