using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(CharacterController))]
public class FPController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float maxSpeed = 5f;
    public float acceleration = 10f;

    public Vector3 CurrentVelocity { get; private set; }
    public float CurrentSpeed { get; private set; }

    [Header("Look Settings")]
    public Vector2 lookSensitivity = new Vector2(0.1f, 0.1f);

    public float pitchLimit = 75f;

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
    [SerializeField] private InputActionReference moveAction;
    public Vector2 moveInput;
    [SerializeField] private InputActionReference lookAction;
    public Vector2 lookInput;

    [Header("Components")]
    [SerializeField] Camera playerCamera;
    [SerializeField] CharacterController characterController;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        moveAction.action.started += HandleMoveInput;
        moveAction.action.performed += HandleMoveInput;
        moveAction.action.canceled += HandleMoveInput;

        lookAction.action.started += HandleLookInput;
        lookAction.action.performed += HandleLookInput;
        lookAction.action.canceled += HandleLookInput;
    }

    private void HandleMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
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

    private void Update()
    {
        moveUpdate();
        lookUpdate();
    }

    void moveUpdate()
    {
        Vector3 motion = transform.forward * moveInput.y + transform.right * moveInput.x;
        motion.y = 0f;
        motion.Normalize();

        if (motion.sqrMagnitude >= 0.01f)
        {
            CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, motion * maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            CurrentVelocity = Vector3.MoveTowards(CurrentVelocity, Vector3.zero, acceleration * Time.deltaTime);
        }

        float verticalVelocity = Physics.gravity.y * 20f * Time.deltaTime;

        Vector3 fullVelocity = new Vector3(CurrentVelocity.x, verticalVelocity, CurrentVelocity.z);

        characterController.Move(fullVelocity * maxSpeed * Time.deltaTime);

        CurrentSpeed = CurrentVelocity.magnitude;
    }

    void lookUpdate()
    {
        Vector2 input = new Vector2(lookInput.x * lookSensitivity.x, lookInput.y * lookSensitivity.y);

        // This is for Up and Down

        CurrentPitch -= input.y;

        playerCamera.transform.localRotation = Quaternion.Euler(CurrentPitch, 0f, 0f);

        // This is for Left and Right

        transform.Rotate(Vector3.up * input.x);
    }
}

