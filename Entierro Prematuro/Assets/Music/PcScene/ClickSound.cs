using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.VisualScripting.Member;

public class ClickSound : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    public void OnPointerClick(PointerEventData eventData)
    {
        source.clip = clip;
        source.Play();
    }
}
