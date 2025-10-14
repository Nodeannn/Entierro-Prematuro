using UnityEngine;
using System.Collections;

public class WindowsManager : MonoBehaviour
{
    public GameObject WindowsStart;
    void Start()
    {
        StartCoroutine(WindowsStarter());
    }
    public IEnumerator WindowsStarter()
    {
        WindowsStart.SetActive(true);

        yield return new WaitForSeconds(5);

        WindowsStart.SetActive(false);
    }
}
