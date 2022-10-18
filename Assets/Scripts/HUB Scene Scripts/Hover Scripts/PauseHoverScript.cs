using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.
using UnityEngine.SceneManagement;

public class PauseHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler// required interface when using the OnPointerEnter method.
{
    // Pause sprites
    public GameObject pauseIcon;
    public Sprite pauseWhite;
    public Sprite pauseRed;

    // Pause screen
    public GameObject pauseScreen;

    // Other screens
    public GameObject journalScreen;
    public GameObject controlsScreen;

    void Start()
    {
        pauseScreen.SetActive(false);
        journalScreen.SetActive(false);
        controlsScreen.SetActive(false);
    }

    void Update()
    {
        //Key presses
        if (Input.GetKeyDown(KeyCode.P) && !pauseScreen.activeSelf && Time.timeScale == 1)
        {
            pauseScreen.SetActive(true);
            //Freeze scene
            Time.timeScale = 0;
            journalScreen.SetActive(false);
            controlsScreen.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.P) && pauseScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
        // Quit
        else if (Input.GetKeyDown(KeyCode.Q) && pauseScreen.activeSelf)
        {
            SceneManager.LoadScene(sceneName: "Title Screen");
        }
    }

    // MOUSE HOVER////////////////////////////////////////////////////////////////
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        pauseIcon.gameObject.GetComponent<Image>().sprite = pauseRed;
    }

    //Mouse exits the UI object
    public void OnPointerExit(PointerEventData eventData)
    {
        pauseIcon.gameObject.GetComponent<Image>().sprite = pauseWhite;
    }

    // MOUSE CLICK////////////////////////////////////////////////////////////////
    //OnPointerDown is also required to receive OnPointerUp callbacks
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!pauseScreen.activeSelf)
        {
            pauseScreen.SetActive(true);
            //Freeze scene
            Time.timeScale = 0;
            journalScreen.SetActive(false);
            controlsScreen.SetActive(false);
        }
        else if (pauseScreen.activeSelf)
        {
            //Resume scene
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }

    }

    //Mouse release
    public void OnPointerUp(PointerEventData eventData)
    {
    }
}