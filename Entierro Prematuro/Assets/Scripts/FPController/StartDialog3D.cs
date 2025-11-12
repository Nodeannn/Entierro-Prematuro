using UnityEngine;

public class StartDialog3D : MonoBehaviour
{
    [SerializeField] private DialogueManager3D dialogueManager;
    [SerializeField] private Dialogue dialogueToStart;

    void Start()
    {
        dialogueManager.StartDialogue(dialogueToStart);
    }
}
