using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

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

    [Header("Interaction Settings")]
    public float actionDuration = 0.1f;

    void Start()
    {
        rayInput.action.performed += HandleRayInput;
    }

    void HandleRayInput(InputAction.CallbackContext context)
    {
        StartCoroutine(ActionTimer());
    }

    IEnumerator ActionTimer()
    {
        rayAction = true;
        yield return new WaitForSeconds(actionDuration);
        rayAction = false;
    }

    private void Update()
    {
        Ray rayCast = new Ray(InteractorSource.position, InteractorSource.forward);

        if (Physics.Raycast(rayCast, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                if (intText != null && UIManager.Instance.allowInteractText)
                {
                    intText.SetActive(true);
                }

                else if (intText != null)
                {
                    intText.SetActive(false);
                }

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
