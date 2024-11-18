using UnityEngine;

/// <summary>
/// Represents a switch that opens a door.
/// </summary>
public class DoorSwitch : InteractableObject
{
    [SerializeField] private Door door;

    public override void Interact(GameObject player)
    {
            door.OpenDoor();
    }
}