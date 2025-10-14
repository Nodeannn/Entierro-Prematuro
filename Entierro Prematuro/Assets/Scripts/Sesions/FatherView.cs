using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FatherView : MonoBehaviour
{
    [SerializeField] public Animator animator;

    public string isTalking = "isTalking";
    public void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void ApplyDialogueLineBools(DialogueLine line)
    {
        animator.SetBool(isTalking, line.isTalking);
    }
}
