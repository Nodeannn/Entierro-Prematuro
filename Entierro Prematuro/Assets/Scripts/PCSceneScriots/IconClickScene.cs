using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class IconClickScene : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public int sceneInt;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneInt);
    }
}
