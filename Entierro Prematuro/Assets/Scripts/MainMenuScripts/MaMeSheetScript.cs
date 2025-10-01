using UnityEngine;
using System.Collections;

public class MaMeSheetScript : MonoBehaviour, IInteractable
{

    [SerializeField] private GameObject sheetImg;

    [SerializeField] private GameObject aftSheetTxt;

    [SerializeField] private GameObject fade;

    [SerializeField] private GameObject player;

    public float showTextDuration = 4f;

    public void Interact()
    {
        StartCoroutine(ShowImage());
    }
    private IEnumerator ShowImage()
    {
        sheetImg.SetActive(true);

        fade.SetActive(true);

        player.GetComponent<FPMenuController>().cameraLock = true;

        UIManager.Instance.allowInteractText = false;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));

        sheetImg.SetActive(false);

        fade.SetActive(false);

        player.GetComponent<FPMenuController>().cameraLock = false;

        aftSheetTxt.SetActive(true);

        yield return new WaitForSeconds(showTextDuration);

        aftSheetTxt.SetActive(false);

        UIManager.Instance.allowInteractText = true;


    }

}
