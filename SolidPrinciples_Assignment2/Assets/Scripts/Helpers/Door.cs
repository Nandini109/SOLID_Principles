using UnityEngine;

/// <summary>
/// Represents a door that can be opened programmatically.
/// </summary>
public class Door : MonoBehaviour
{
    [Header("Door Settings")]
    [SerializeField] private float openSpeed = 2f; // Speed of door opening
    [SerializeField] private Vector3 openRotation = new Vector3(0, 90, 0); // Desired rotation when opened
    [SerializeField] private Transform doorTransform; // Transform of the door object

    private bool isOpen = false; // Tracks the door's state
    private Quaternion initialRotation; // Initial rotation of the door
    private Quaternion targetRotation; // Target rotation when the door is open

    private void Start()
    {
        if (doorTransform == null)
        {
            doorTransform = transform; // Default to this object's transform
        }

        // Initialize rotations
        initialRotation = doorTransform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(openRotation);
    }

    /// Opens the door programmatically with a smooth animation.
    public void OpenDoor()
    {
        if (!isOpen)
        {
            Debug.Log("Opening door...");
            isOpen = true;
            StopAllCoroutines(); // Stop any ongoing animations
            StartCoroutine(AnimateDoor(targetRotation)); // Animate to the open position
        }
    }

    /// Smoothly animates the door's rotation to the target rotation.
    private System.Collections.IEnumerator AnimateDoor(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        Quaternion currentRotation = doorTransform.rotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * openSpeed;
            doorTransform.rotation = Quaternion.Slerp(currentRotation, targetRotation, elapsedTime);
            yield return null;
        }

        doorTransform.rotation = targetRotation; // Ensure final rotation is precise
    }
}
