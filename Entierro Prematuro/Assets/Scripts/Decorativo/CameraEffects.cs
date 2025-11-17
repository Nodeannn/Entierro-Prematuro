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
        if (!whiteCanvasGroup) whiteCanvasGroup = whitePanel.GetComponent<CanvasGroup>();
        if (!blackCanvasGroup) blackCanvasGroup = blackPanel.GetComponent<CanvasGroup>();

        whiteCanvasGroup.alpha = 0f;
        blackCanvasGroup.alpha = 0f;

        originalCameraPos = cameraTransform.position;
    }

    public void BulletImpactEffect()
    {
        StartCoroutine(BulletImpactRoutine());
    }

    private IEnumerator BulletImpactRoutine()
    {

        float elapsed = 0f;
        while (elapsed < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            cameraTransform.position = originalCameraPos + randomOffset;
            elapsed += Time.deltaTime;
            yield return null;
        }
        cameraTransform.position = originalCameraPos;


        yield return StartCoroutine(FadePanel(whiteCanvasGroup, 0f, 1f, 0.1f));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(FadePanel(whiteCanvasGroup, 1f, 0f, 0.3f));
    }

    public void VisionBlackoutEffect()
    {
        StartCoroutine(VisionBlackoutRoutine(3));
    }

    private IEnumerator VisionBlackoutRoutine(int blinks)
    {
        float initialSpeed = 0.5f;
        float speedIncrement = 0.5f;

        for (int i = 0; i < blinks; i++)
        {
            float duration = initialSpeed + i * speedIncrement;


            yield return StartCoroutine(FadePanel(blackCanvasGroup, 0f, 1f, duration / 2f));


            if (i == blinks - 1)
                yield break;


            yield return StartCoroutine(FadePanel(blackCanvasGroup, 1f, 0f, duration / 2f));
        }
    }


    private IEnumerator FadePanel(CanvasGroup cg, float from, float to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            cg.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cg.alpha = to;
    }
}