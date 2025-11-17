using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FatherView : MonoBehaviour
{
    [SerializeField] public Animator animator;

    public string isMirandoAbajo = "isMirandoAbajo";
    public string isMirandoCostado = "isMirandoCostado";
    public string isMirandoDerecha = "isMirandoDerecha";
    public string isAbajo = "isAbajo";
    public string isHablando1 = "isHablando1";
    public string isHablando2 = "isHablando2";
    public string isMedioFeliz = "isMedioFeliz";
    public string isConmovido = "isConmovido";
    public string isFeliz = "isFeliz";
    public string isEnojado = "isEnojado";
    public string isMasEnojado = "isMasEnojado";
    public string isHablandoMuyEnojado = "isHablandoMuyEnojado";
    public string isHablandoEnojado = "isHablandoEnojado";
    public string isMedioTriste = "isMedioTriste";
    public string isLlorando = "isLlorando";
    public string isTriste = "isTriste";
    public string isPreocupado = "isPreocupado";
    public string isAsustarse = "isAsustarse";
    public string isAsustado = "isAsustado";
    public string isExtremoEnojado = "isExtremoEnojado";
    public string isExtremoQCY = "isExtremoQCY";
    public string isExtremoHorror = "isExtremoHorror";
    public string isMuyFeliz = "isMuyFeliz";
    public string isChicaInterposicion = "Chica_Interposicion";
    public string isChicaFeliz = "Chica_Feliz";
    public string isChicaColgada = "Chica_Colgada";
    public string isChicaNeutro = "Chica_neutro";
    public string isAsustadoHablando = "Asustado_Hablando";

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


        animator.SetBool(isMirandoAbajo, line.isMirandoAbajo);
        animator.SetBool(isMirandoCostado, line.isMirandoCostado);
        animator.SetBool(isMirandoDerecha, line.isMirandoDerecha);
        animator.SetBool(isAbajo, line.isAbajo);
        animator.SetBool(isHablando1, line.isHablando1);
        animator.SetBool(isHablando2, line.isHablando2);
        animator.SetBool(isMedioFeliz, line.isMedioFeliz);
        animator.SetBool(isConmovido, line.isConmovido);
        animator.SetBool(isFeliz, line.isFeliz);
        animator.SetBool(isEnojado, line.isEnojado);
        animator.SetBool(isMasEnojado, line.isMasEnojado);
        animator.SetBool(isHablandoMuyEnojado, line.isHablandoMuyEnojado);
        animator.SetBool(isHablandoEnojado, line.isHablandoEnojado);
        animator.SetBool(isMedioTriste, line.isMedioTriste);
        animator.SetBool(isLlorando, line.isLlorando);
        animator.SetBool(isTriste, line.isTriste);
        animator.SetBool(isPreocupado, line.isPreocupado);
        animator.SetBool(isAsustarse, line.isAsustarse);
        animator.SetBool(isAsustado, line.isAsustado);
        animator.SetBool(isExtremoEnojado, line.isExtremoEnojado);
        animator.SetBool(isExtremoQCY, line.isExtremoQCY);
        animator.SetBool(isExtremoHorror, line.isExtremoHorror);
        animator.SetBool(isMuyFeliz, line.isMuyFeliz);
        animator.SetBool(isChicaInterposicion, line.isChicaInterposicion); 
        animator.SetBool(isChicaFeliz, line.isChicaFeliz);
        animator.SetBool(isChicaColgada, line.isChicaColgada);
        animator.SetBool(isChicaNeutro, line.isChicaNeutro);
        animator.SetBool(isAsustadoHablando, line.isAsustadoHablando);
    }

    private void ResetAllBools()
    {
        animator.SetBool(isMirandoAbajo, false);
        animator.SetBool(isMirandoCostado, false);
        animator.SetBool(isMirandoDerecha, false);
        animator.SetBool(isAbajo, false);
        animator.SetBool(isHablando1, false);
        animator.SetBool(isHablando2, false);
        animator.SetBool(isMedioFeliz, false);
        animator.SetBool(isConmovido, false);
        animator.SetBool(isFeliz, false);
        animator.SetBool(isEnojado, false);
        animator.SetBool(isMasEnojado, false);
        animator.SetBool(isHablandoMuyEnojado, false);
        animator.SetBool(isHablandoEnojado, false);
        animator.SetBool(isMedioTriste, false);
        animator.SetBool(isLlorando, false);
        animator.SetBool(isTriste, false);
        animator.SetBool(isPreocupado, false);
        animator.SetBool(isAsustarse, false);
        animator.SetBool(isAsustado, false);
        animator.SetBool(isExtremoEnojado, false);
        animator.SetBool(isExtremoQCY, false);
        animator.SetBool(isExtremoHorror, false);
        animator.SetBool(isMuyFeliz, false);
        animator.SetBool(isChicaInterposicion, false);
        animator.SetBool(isChicaFeliz, false);
        animator.SetBool(isChicaColgada, false);
        animator.SetBool(isChicaNeutro, false);
        animator.SetBool(isAsustadoHablando, false);
    }


}
