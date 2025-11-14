using UnityEngine;

public class Sesion4Touch : MonoBehaviour
{
    [SerializeField] private DialogueManager3D dialogueManager;
    [SerializeField] private Dialogue dialogueToStart;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogueManager.StartDialogue(dialogueToStart);
        }
    }
}
