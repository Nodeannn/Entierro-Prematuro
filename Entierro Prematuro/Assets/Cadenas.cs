using UnityEngine;
using System.Collections;

public class Cadenas : MonoBehaviour
{
    [SerializeField] GameObject cadenas;
    [SerializeField] GameObject faros;
    private void Start()
    {
        StartCoroutine(CadenasTime());
    }

    IEnumerator CadenasTime()
    {
        yield return new WaitForSeconds(1);
        faros.SetActive(false);
    }
}
