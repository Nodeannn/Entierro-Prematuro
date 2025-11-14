using UnityEngine;

public class SetSesionGlobal : MonoBehaviour
{
    [SerializeField] private int points = 0;

    private void Start()
    {
        GameManager.instance.SetScore(points);
    }
}
