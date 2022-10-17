using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
public class JournalHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler// required interface when using the OnPointerEnter method.
{
    // Journal sprite
    public GameObject journalIcon;
    public Sprite journalWhite;
    public Sprite journalRed;

    // Journal screen
    public GameObject journalScreen;

    // Other screens
    public GameObject controlsScreen;
    public GameObject pauseScreen;

    void Start()
    {
        journalScreen.SetActive(false);
        controlsScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    void Update()
    {
        //Key presses
        if (Input.GetKeyDown(KeyCode.J) && !journalScreen.activeSelf)
        {
            journalScreen.SetActive(true);
            //Freeze scene
            Time.timeScale = 0;
            controlsScreen.SetActive(false);
            pauseScreen.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Escape) && journalScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            journalScreen.SetActive(false);
        }
    }

    // MOUSE HOVER////////////////////////////////////////////////////////////////
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        journalIcon.gameObject.GetComponent<Image>().sprite = journalRed;
    }

    //Mouse exits the UI object
    public void OnPointerExit(PointerEventData eventData)
    {
        journalIcon.gameObject.GetComponent<Image>().sprite = journalWhite;
    }

    // MOUSE CLICK////////////////////////////////////////////////////////////////
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!journalScreen.activeSelf)
        {
            journalScreen.SetActive(true);
            //Freeze scene
            Time.timeScale = 0;
            controlsScreen.SetActive(false);
            pauseScreen.SetActive(false);
        }
        else if (journalScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            journalScreen.SetActive(false);
        }

    }

    //Mouse release
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}