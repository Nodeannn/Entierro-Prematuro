using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraEffects : MonoBehaviour
{
    [Header("Paneles")]
    public Image whitePanel;
    public Image blackPanel;
    public CanvasGroup whiteCanvasGroup;
    public CanvasGroup blackCanvasGroup;

    [Header("Shake cámara")]
    public Transform cameraTransform;
    public float shakeMagnitude = 0.2f;
    public float shakeDuration = 0.2f;

    [Header("Blackout")]
    public float blackoutSpeed = 0.5f;

    private Vector3 originalCameraPos;

    private void Awake()
    {
        if (!whiteCanvasGroup && whitePanel)
            whiteCanvasGroup = whitePanel.GetComponent<CanvasGroup>();
        if (!blackCanvasGroup && blackPanel)
            blackCanvasGroup = blackPanel.GetComponent<CanvasGroup>();

        if (whiteCanvasGroup) whiteCanvasGroup.alpha = 0f;
        if (blackCanvasGroup) blackCanvasGroup.alpha = 0f;

        if (cameraTransform) originalCameraPos = cameraTransform.position;
    }

    /// <summary>
    /// Llama a este método desde DialogueLine para disparar efectos
    /// </summary>
    public void ApplyEffectsFromDialogue(DialogueLine line)
    {
        if (line == null) return;

        if (line.EfectoDisparo)
        {
            BulletImpactEffect();
            line.EfectoDisparo = false; // resetea para que no se repita
        }

        if (line.EfectoMuerte)
        {
            VisionBlackoutEffect();
            line.EfectoMuerte = false; // resetea para que no se repita
        }
    }

    #region Efectos

    public void BulletImpactEffect()
    {
        if (cameraTransform)
            StartCoroutine(BulletImpactRoutine());
    }

    private IEnumerator BulletImpactRoutine()
    {
        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            if (cameraTransform)
                cameraTransform.position = originalCameraPos + randomOffset;
            elapsed += Time.deltaTime;
            yield return null;
        }
        if (cameraTransform)
            cameraTransform.position = originalCameraPos;

        if (whiteCanvasGroup)
        {
            yield return StartCoroutine(FadePanel(whiteCanvasGroup, 0f, 1f, 0.1f));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(FadePanel(whiteCanvasGroup, 1f, 0f, 0.3f));
        }
    }

    public void VisionBlackoutEffect()
    {
        if (blackCanvasGroup)
            StartCoroutine(VisionBlackoutRoutine(3));
    }

    private IEnumerator VisionBlackoutRoutine(int blinks)
    {
        float initialSpeed = 0.5f;
        float speedIncrement = 0.5f;

        for (int i = 0; i < blinks; i++)
        {
            float duration = initialSpeed + i * speedIncrement;

            if (blackCanvasGroup)
                yield return StartCoroutine(FadePanel(blackCanvasGroup, 0f, 1f, duration / 2f));

            if (i == blinks - 1) break;

            if (blackCanvasGroup)
                yield return StartCoroutine(FadePanel(blackCanvasGroup, 1f, 0f, duration / 2f));
        }
    }

    private IEnumerator FadePanel(CanvasGroup cg, float from, float to, float duration)
    {
        if (cg == null) yield break;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            cg.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cg.alpha = to;
    }

    #endregion
}
