using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;



    public void Update()
    {
        
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Method to reduce enemy's health
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die(); // If health drops to 0 or below, enemy dies
        }
    }

    // Method to handle enemy's death
    private void Die()
    {
        // Add any death animations, effects, or logic here
        Debug.Log("Enemy died!");
        Destroy(gameObject); // Destroy the enemy game object
    }
}
