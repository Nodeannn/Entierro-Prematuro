using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragWindow : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    private RectTransform windowTransform;
    private Canvas canvas;
    private Vector2 offset;

    private void Start()
    {
        windowTransform = transform.parent.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            windowTransform, eventData.position, eventData.pressEventCamera, out offset);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint))
        {
            windowTransform.localPosition = localPoint - offset;
        }
    }
}
