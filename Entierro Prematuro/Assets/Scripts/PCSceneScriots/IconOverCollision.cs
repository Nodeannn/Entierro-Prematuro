using UnityEngine;
using UnityEngine.EventSystems;

public class IconOverCollision : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject program;

    public void OnPointerEnter(PointerEventData eventData)
    {
        program.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        program.SetActive(false);
    }
}
