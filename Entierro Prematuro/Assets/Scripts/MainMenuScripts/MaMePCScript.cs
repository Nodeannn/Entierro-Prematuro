using UnityEngine;
using UnityEngine.SceneManagement;

public class MaMePCScript : MonoBehaviour,IInteractable
{

    [SerializeField] public int sceneInt;

    public void Interact()
    {
        SceneManager.LoadScene(sceneInt);
    }

}
