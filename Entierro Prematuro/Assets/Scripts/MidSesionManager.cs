using UnityEngine;
using System.Collections;
using UnityEditor.SceneManagement;
using NUnit.Framework.Internal;
using UnityEngine.SceneManagement;

public class MidSesionManager : MonoBehaviour
{
    [SerializeField] GameObject texto;
    [SerializeField] private float time = 1f;
    [SerializeField] private float timeScene = 1f;
    [SerializeField] private string nextScene = "";

    private void Start()
    {
        texto.SetActive(false);
        StartCoroutine(SesionInicio());
    }

    IEnumerator SesionInicio()
    {
        yield return new WaitForSeconds(time);

        texto.SetActive(true);

        yield return new WaitForSeconds(timeScene);

        SceneManager.LoadScene(nextScene);
    }
}
