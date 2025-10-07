using UnityEngine;
using System.Collections;

public class SesionManagement : MonoBehaviour
{
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;
    void Start()
    {
        StartCoroutine(SesionManage());
    }

    private IEnumerator SesionManage()
    {
        text1.SetActive(true);

        yield return new WaitFor
    }

}
