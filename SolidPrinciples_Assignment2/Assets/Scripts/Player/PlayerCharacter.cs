using UnityEngine;

/// Handles player movement relative to the camera's direction in a third-person style.
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float rotationSpeed = 10f; 
    private CharacterController characterController;
    private Transform cameraTransform;
    private Animator animator;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;

        if (characterController == null)
        {
            Debug.LogError("CharacterController component missing!");
        }

        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    /// Moves and rotates the player based on input relative to the camera's direction.
    private void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        

        if (inputDirection.magnitude > 0.1f)
        {
            Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 cameraRight = cameraTransform.right;

            Vector3 moveDirection = (cameraForward * inputDirection.z + cameraRight * inputDirection.x).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            characterController.Move(moveDirection * (moveSpeed * Time.deltaTime));

            animator.SetBool("IsWalking", true);
        }

        if (inputDirection.magnitude < 0.1f)
        {
            animator.SetBool("IsWalking", false);
        }
    }

}
