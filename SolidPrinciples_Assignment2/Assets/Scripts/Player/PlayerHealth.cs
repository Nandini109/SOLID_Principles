using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        
        Debug.Log($"Game started. Player health: {currentHealth}");
    }

    /// Increases the player's health.
    public void IncreaseHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"Player health: {currentHealth}");
    }

    /// Decreases the player's health.
    public void DecreaseHealth(int amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0);
        Debug.Log($"Player health: {currentHealth}");
        if (currentHealth <= 0)
        {
            Debug.Log("Player is dead!");
            Destroy(gameObject);
        }
    }
}
