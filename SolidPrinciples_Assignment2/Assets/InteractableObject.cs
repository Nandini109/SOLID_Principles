using UnityEngine;

/// Base class for all interactable objects in the game.
/// For Open-Closed Principle.
public abstract class InteractableObject : MonoBehaviour
{
    public abstract void Interact(GameObject player);
}
