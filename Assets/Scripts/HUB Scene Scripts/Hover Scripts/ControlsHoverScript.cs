using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class ControlsHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler// required interface when using the OnPointerEnter method.
{
    // Controls sprite
    public GameObject controlsIcon;
    public Sprite controlsWhite;
    public Sprite controlsRed;

    // Controls screen
    public GameObject controlsScreen;

    // Other screens
    public GameObject journalScreen;
    public GameObject pauseScreen;

    void Start()
    {
        controlsScreen.SetActive(false);
        journalScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        //Key presses
        if (Input.GetKeyDown(KeyCode.C) && !controlsScreen.activeSelf)
        {
            controlsScreen.SetActive(true);
            //Freeze scene
            Time.timeScale = 0;
            journalScreen.SetActive(false);
            pauseScreen.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Escape) && controlsScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            controlsScreen.SetActive(false);
        }
    }

    // MOUSE HOVER////////////////////////////////////////////////////////////////
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        controlsIcon.gameObject.GetComponent<Image>().sprite = controlsRed;
    }

    //Mouse exits the UI object
    public void OnPointerExit(PointerEventData eventData)
    {
        controlsIcon.gameObject.GetComponent<Image>().sprite = controlsWhite;
    }

    // MOUSE CLICK////////////////////////////////////////////////////////////////
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!controlsScreen.activeSelf)
        {
            controlsScreen.SetActive(true);
            //Freeze scene
            Time.timeScale = 0;
            journalScreen.SetActive(false);
            pauseScreen.SetActive(false);
        }
        else if (controlsScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            controlsScreen.SetActive(false);
        }

    }

    //Mouse release
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}