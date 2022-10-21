using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ExitUIScript : MonoBehaviour, IPointerDownHandler
{
    // Screens
    public GameObject journalScreen;
    public GameObject controlsScreen;
    public GameObject pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (journalScreen.activeSelf || controlsScreen.activeSelf || pauseScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            journalScreen.SetActive(false);
            controlsScreen.SetActive(false);
            pauseScreen.SetActive(false);
        }

    }

    //Mouse release
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
