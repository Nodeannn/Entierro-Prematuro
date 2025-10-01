using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;

    public bool allowInteractText = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }    
    }

}
