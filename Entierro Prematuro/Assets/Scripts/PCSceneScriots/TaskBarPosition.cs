using UnityEngine;

public class TaskBarPosition : MonoBehaviour
{
    [SerializeField] private GameObject recycleBinIcon;
    [SerializeField] private GameObject settingsIcon;
    [SerializeField] private GameObject notePadIcon;

    [SerializeField] private GameObject recycleBinWindow;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject notePadWindow;

    [SerializeField] private Vector3 startPos = new Vector3(-681, -520, 0);
    [SerializeField] private float iconSpacing = 120f;
    private int nextSlot = 0;

    private void Update()
    {
        nextSlot = 0;


        if (settingsWindow.activeSelf)
        {
            settingsIcon.SetActive(true);
            settingsIcon.transform.localPosition = startPos + new Vector3(iconSpacing * nextSlot, 0, 0);
            nextSlot++;
        }
        else settingsIcon.SetActive(false);

        if (recycleBinWindow.activeSelf)
        {
            recycleBinIcon.SetActive(true);
            recycleBinIcon.transform.localPosition = startPos + new Vector3(iconSpacing * nextSlot, 0, 0);
            nextSlot++;
        }
        else recycleBinIcon.SetActive(false);

        if (notePadWindow.activeSelf)
        {
            notePadIcon.SetActive(true);
            notePadIcon.transform.localPosition = startPos + new Vector3(iconSpacing * nextSlot, 0, 0);
            nextSlot++;
        }
        else notePadIcon.SetActive(false);
    }
}
