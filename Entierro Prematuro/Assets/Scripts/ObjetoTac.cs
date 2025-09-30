using UnityEngine;

public class ObjectTac : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(Random.Range(0,100));
    }
}