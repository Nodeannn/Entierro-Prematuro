using UnityEngine;
using UnityEngine.EventSystems;

public class IconClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject programa;

    public void OnPointerClick(PointerEventData eventData)
    {
        programa.SetActive(true);

    }

}
