using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clip;

    void Start()
    {
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
}
