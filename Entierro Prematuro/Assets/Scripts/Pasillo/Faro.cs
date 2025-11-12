using UnityEngine;
using System.Collections;

public class Faro : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueManager3D dialogueManager;
    [SerializeField] private Dialogue dialogueToStart;
    [SerializeField] private bool oneTime = true;
    [SerializeField] private GameObject nextObject;

    private bool hasActivated = false;

    public void Interact()
    {
        if(!hasActivated)
        {
            dialogueManager.StartDialogue(dialogueToStart);

            if (oneTime)
            {
                hasActivated = true;
            }
        }
        nextObject.SetActive(true);
    }
}
