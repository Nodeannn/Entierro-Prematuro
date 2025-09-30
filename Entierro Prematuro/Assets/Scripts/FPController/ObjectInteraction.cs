using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class ObjectInteraction : MonoBehaviour
{
   
    [Header("Raycast Settings")]
    public Transform InteractorSource;
    public float InteractRange;

    [Header("Raycast Input")]
    [SerializeField] private InputActionReference rayInput;
    public bool rayAction;

    void Start()
    {
        rayInput.action.performed += HandleRayInput;
    }

    void HandleRayInput(InputAction.CallbackContext context)
    {
        bool rayUse = context.ReadValue<bool>();

        if(rayUse == true)
        {
            Ray rayCast = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(rayCast, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }
        }
        }
    }
}
