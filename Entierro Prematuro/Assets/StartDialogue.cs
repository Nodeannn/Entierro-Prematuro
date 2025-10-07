using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Dialogue dialogueToStart;

    void Start()
    {
        dialogueManager.StartDialogue(dialogueToStart);
    }

}
