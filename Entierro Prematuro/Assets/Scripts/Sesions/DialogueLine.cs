using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speaker;
    [TextArea(2, 5)] public string text;

    public bool isMirandoAbajo = false;
    public bool isMirandoCostado = false;
    public bool isMirandoDerecha = false;
    public bool isAbajo = false;
    public bool isHablando1 = false;
    public bool isHablando2 = false;
    public bool isMedioFeliz = false;
    public bool isConmovido = false;
    public bool isFeliz = false;
    public bool isEnojado = false;
    public bool isMasEnojado = false;
    public bool isHablandoMuyEnojado = false;
    public bool isHablandoEnojado = false;
    public bool isMedioTriste = false;
    public bool isLlorando = false;
    public bool isTriste = false;
    public bool isPreocupado = false;
    public bool isAsustarse = false;
    public bool isAsustado = false;
    public bool isExtremoEnojado = false;
    public bool isExtremoQCY = false;
    public bool isExtremoHorror = false;
}