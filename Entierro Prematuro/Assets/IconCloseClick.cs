using UnityEngine;
using UnityEngine.EventSystems;

public class IconCloseClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject programa;

    public void OnPointerClick(PointerEventData eventData)
    {
        programa.SetActive(false);
    }
}
