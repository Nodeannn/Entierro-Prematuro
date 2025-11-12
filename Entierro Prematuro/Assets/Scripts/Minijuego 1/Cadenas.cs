using UnityEngine;
using System.Collections;

public class Cadenas : MonoBehaviour
{
    [SerializeField] FPController player;
    [SerializeField] GameObject Doll;
    [SerializeField] GameObject Glass;
    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Doll.SetActive(false);
            Glass.SetActive(false);

            if (player != null)
                player.LockPlayerControls(true);
        }
    }
}
