using UnityEngine;
using System.Collections;

public class ApagadoFarol : MonoBehaviour
{
    [SerializeField] private GameObject lightFarol;
    [SerializeField] private GameObject light2Farol;
    [SerializeField] private float timeFarol = 3f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sound;

    void Start()
    {
        StartCoroutine(ApagadoFarolLuz());

    }

    IEnumerator ApagadoFarolLuz()
    {
        yield return new WaitForSeconds(timeFarol);

        lightFarol.SetActive(false);
        light2Farol.SetActive(true);
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound);
        }

    }    
}
