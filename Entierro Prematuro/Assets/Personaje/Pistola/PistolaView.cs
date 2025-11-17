using UnityEngine;

public class PistolaView : MonoBehaviour
{
    [SerializeField] public Animator animator;

    public string nada = "Nada";
    public string ElMismo = "ElMismo";
    public string player = "Player";

    public void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("Animator no encontrado en FatherView!");

    }

    public void ApplyDialogueLineBools(DialogueLine line)
    {

        ResetAllBools();
        Debug.Log("Aplicando línea: " + line.text);
        animator.SetBool(nada, line.manosNada);
        animator.SetBool(ElMismo, line.manosElMismo);
        animator.SetBool(player, line.manosAPlayer);
    }

    private void ResetAllBools()
    {
        animator.SetBool(nada, false);
        animator.SetBool(ElMismo , false);
        animator.SetBool(player, false);
    }
}
