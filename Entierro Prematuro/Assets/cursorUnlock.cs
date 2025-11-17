using UnityEngine;

public class cursorUnlock : MonoBehaviour
{
    void Start()
    {
        // Hacer visible el cursor
        Cursor.visible = true;

        // Desbloquear el cursor
        Cursor.lockState = CursorLockMode.None;
    }
}
