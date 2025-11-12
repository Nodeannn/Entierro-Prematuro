using UnityEngine;

public class MouseAgain : MonoBehaviour
{

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
