using UnityEngine;
using System.Collections;
public class Credits : MonoBehaviour
{
    [SerializeField] private GameObject credits1;
    [SerializeField] private GameObject credits2;
    [SerializeField] private GameObject credits3;
    [SerializeField] private GameObject credits4;
    [SerializeField] private GameObject credits5;
    [SerializeField] private GameObject credits6;
    [SerializeField] private GameObject credits7;
    [SerializeField] private GameObject credits8;
    [SerializeField] private GameObject credits9;
    [SerializeField] private GameObject credits10;
    [SerializeField] private GameObject credits11;
    [SerializeField] private GameObject credits12;
    [SerializeField] private GameObject credits13;
    [SerializeField] private GameObject credits14;
    [SerializeField] private GameObject credits15;
    [SerializeField] private GameObject credits16;

    [SerializeField] private float time = 4;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        source.clip = clip;
        source.Play();
        StartCoroutine(CreditsPlay());
    }
    private IEnumerator CreditsPlay()
    {
        credits1.SetActive(true);
        yield return new WaitForSeconds(time);
        credits1.SetActive(false);
        credits2.SetActive(true);
        yield return new WaitForSeconds(time);

        credits2.SetActive(false);
        credits3.SetActive(true);
        yield return new WaitForSeconds(time);

        credits3.SetActive(false);
        credits4.SetActive(true);
        yield return new WaitForSeconds(time);

        credits4.SetActive(false);
        credits5.SetActive(true);
        yield return new WaitForSeconds(time);

        credits5.SetActive(false);
        credits6.SetActive(true);
        yield return new WaitForSeconds(time);

        credits6.SetActive(false);
        credits7.SetActive(true);
        yield return new WaitForSeconds(time);

        credits7.SetActive(false);
        credits8.SetActive(true);
        yield return new WaitForSeconds(time);

        credits8.SetActive(false);
        credits9.SetActive(true);
        yield return new WaitForSeconds(time);

        credits9.SetActive(false);
        credits10.SetActive(true);
        yield return new WaitForSeconds(time);

        credits10.SetActive(false);
        credits11.SetActive(true);
        yield return new WaitForSeconds(time);

        credits11.SetActive(false);
        credits12.SetActive(true);
        yield return new WaitForSeconds(time);

        credits12.SetActive(false);
        credits13.SetActive(true);
        yield return new WaitForSeconds(time);

        credits13.SetActive(false);
        credits14.SetActive(true);
        yield return new WaitForSeconds(time);

        credits14.SetActive(false);
        credits15.SetActive(true);
        yield return new WaitForSeconds(time);

        credits15.SetActive(false);
        credits16.SetActive(true);
        yield return new WaitForSeconds(time);

        credits16.SetActive(false);
    }

}
