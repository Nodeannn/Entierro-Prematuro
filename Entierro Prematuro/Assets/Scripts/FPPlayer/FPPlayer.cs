using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[RequireComponent(typeof(FPController))]
public class FPPlayer : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] FPController controller;
    [SerializeField] ObjectInteraction interaction;
    
    void OnMove(InputValue value)
    {
        controller.moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        controller.lookInput = value.Get<Vector2>();
    }

    private void OnValidate()
    {
        if (controller == null)
        {
            controller = GetComponent<FPController>();
        }
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
