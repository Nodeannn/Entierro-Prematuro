using UnityEngine;
using System.Collections;

public class ParpadeoFaro : MonoBehaviour
{
    [SerializeField] private GameObject lightFarol;

    private void Start()
    {
        StartCoroutine(Parpadeo());
    }

    IEnumerator Parpadeo()
    {
        lightFarol.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        lightFarol.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        lightFarol.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        lightFarol.SetActive(true);

        StartCoroutine(Parpadeo());
    }
}
