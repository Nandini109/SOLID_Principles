using UnityEngine;

/// A collectable coin in game.
public class Coin : InteractableObject
{
    public override void Interact(GameObject player)
    {
        ScoreManager.Instance.AddScore(1);
        Destroy(gameObject);
    }
}