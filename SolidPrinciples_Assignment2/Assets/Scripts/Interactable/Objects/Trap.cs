using UnityEngine;

/// Reduces player health on collision.
public class Trap : InteractableObject
{
    [SerializeField] private int damageAmount = 10;

    public override void Interact(GameObject player)
    {
        Debug.Log($"Player health decreased by: {damageAmount}");
        player.GetComponent<PlayerHealth>().DecreaseHealth(damageAmount);
    }
}