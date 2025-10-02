using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class IconCloseClick : MonoBehaviour
{
    [SerializeField] private GameObject programa;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(closeProgram());
        Debug.Log("Hiciste Click");
    }

    private IEnumerator closeProgram()
    {
        yield return new WaitForSeconds(0.01f);
        
    }

}
