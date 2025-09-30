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

    [SerializeField] public GameObject intText;

    void Start()
    {
        rayInput.action.performed += HandleRayInput;
    }

    void HandleRayInput(InputAction.CallbackContext context)
    {
        rayAction = true;
    }

    private void Update()
    {
        Ray rayCast = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(rayCast, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (intText != null)
                    intText.SetActive(true);

                if (rayAction)
                {
                    interactObj.Interact();
                    rayAction = false;
                }
            }
            else
            {
                if (intText != null)
                    intText.SetActive(false);
            }
        }
        else
        {
            if (intText != null)
                intText.SetActive(false);
        }
    }
}
