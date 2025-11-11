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

    public void Awake()
    {
        animator = GetComponent<Animator>();

    }

    public void ApplyDialogueLineBools(DialogueLine line)
    {
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
    }
}
