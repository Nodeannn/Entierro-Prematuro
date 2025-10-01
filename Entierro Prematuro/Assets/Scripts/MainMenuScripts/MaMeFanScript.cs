using UnityEngine;
using System.Collections;

public class MaMeFanScript : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject fanText;

    public float showTextDuration = 4f;

    public void Interact()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        fanText.SetActive(true);
        UIManager.Instance.allowInteractText = false;

        yield return new WaitForSeconds(showTextDuration);

        fanText.SetActive(false);
        UIManager.Instance.allowInteractText = true;
    }
}
