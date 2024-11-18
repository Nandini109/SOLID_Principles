using UnityEngine;

/// Health pickup in game.
public class HealthPickup : InteractableObject
{
    [SerializeField] private int healthAmount = 10;

    public override void Interact(GameObject player)
    {
        Debug.Log($"Player health increased by {healthAmount}");
        player.GetComponent<PlayerHealth>().IncreaseHealth(healthAmount);
        Destroy(gameObject);
    }
}