using UnityEngine;

/// Detects and interacts with objects.
public class ObjectInteractor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        InteractableObject interactable = other.GetComponent<InteractableObject>();
        if (interactable != null)
        {
            interactable.Interact(gameObject);
        }
    }
}