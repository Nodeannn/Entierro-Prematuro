using UnityEngine;
using System.Collections;

public class ApagadoFarol : MonoBehaviour
{
    [SerializeField] private GameObject lightFarol;
    [SerializeField] private float timeFarol = 3f;

    void Start()
    {
        StartCoroutine(ApagadoFarolLuz());

    }

    IEnumerator ApagadoFarolLuz()
    {
        yield return new WaitForSeconds(timeFarol);

        lightFarol.SetActive(false);

    }    
}
