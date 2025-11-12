using UnityEngine;

public class MirrorHija : MonoBehaviour
{
    [SerializeField] private GameObject mirror;

    private void OnEnable()
    {
        mirror.SetActive(false);
    }
}
