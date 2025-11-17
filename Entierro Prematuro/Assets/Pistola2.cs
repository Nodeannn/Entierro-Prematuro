using UnityEngine;

public class Pistola2 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer pistola;
    void Start()
    {
        pistola.enabled = false;
        pistola = GetComponent<SpriteRenderer>();
    }
    public void ActualizarPistola(DialogueLine line)
    {
        pistola.enabled = line.manosAPlayer;
    }
}
