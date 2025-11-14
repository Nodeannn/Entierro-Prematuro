using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioSource footstepsAudio;
    [SerializeField] private CharacterController controller;

    private void Update()
    {
        bool isMoving = controller.velocity.magnitude > 0.1f && controller.isGrounded;

        if (isMoving)
        {
            if (!footstepsAudio.isPlaying)
                footstepsAudio.Play();
        }
        else
        {
            if (footstepsAudio.isPlaying)
                footstepsAudio.Stop();
        }
    }
}