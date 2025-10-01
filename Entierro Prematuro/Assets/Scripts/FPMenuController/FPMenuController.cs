using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FPMenuController : MonoBehaviour
{

    [Header("Look Settings")]
    public Vector2 lookSensitivity = new Vector2(0.1f, 0.1f);

    public float pitchLimit = 75f;

    public bool cameraLock = false;

    [SerializeField] float currentPitch = 0f;

    public float CurrentPitch
    {
        get => currentPitch;

        set
        {
            currentPitch = Mathf.Clamp(value, -pitchLimit, pitchLimit);
        }
    }

    [Header("Input")]
    [SerializeField] private InputActionReference lookAction;
    public Vector2 lookInput;

    [Header("Components")]
    [SerializeField] Camera playerCamera;
    [SerializeField] CharacterController characterController;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        lookAction.action.started += HandleLookInput;
        lookAction.action.performed += HandleLookInput;
        lookAction.action.canceled += HandleLookInput;
    }

    private void HandleLookInput(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void OnValidate()
    {
        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();
        }

        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        lookUpdate();
    }

    void lookUpdate()
    {
        if (cameraLock == false)
        {
            Vector2 input = new Vector2(lookInput.x * lookSensitivity.x, lookInput.y * lookSensitivity.y);

            // This is for Up and Down

            CurrentPitch -= input.y;

            playerCamera.transform.localRotation = Quaternion.Euler(CurrentPitch, 0f, 0f);

            // This is for Left and Right

            transform.Rotate(Vector3.up * input.x);
        }
    }
}
