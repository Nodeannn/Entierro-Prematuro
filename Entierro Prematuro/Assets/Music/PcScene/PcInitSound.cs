using UnityEngine;

public class PcInitSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        source.clip = clip;
        source.Play();
    }
}
