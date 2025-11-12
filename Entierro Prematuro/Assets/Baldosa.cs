using UnityEngine;

public class Baldosa : MonoBehaviour
{
    [SerializeField] GameObject baldosa;
    [SerializeField] GameObject player;
    void OnEnable()
    {
        baldosa.transform.localPosition = player.transform.localPosition =new Vector3(player.transform.localPosition.x, baldosa.transform.localPosition.y, player.transform.localPosition.z);
    }
}
