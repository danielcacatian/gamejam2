using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour
{
    public GameObject forward;
    public Sprite forwardWhite;
    public Sprite forwardRed;

    public GameObject tutorialBG;
    public Sprite[] tutorialScreens;
    int arrayPos = 0; 

    public AudioSource hoverSFX;

    private bool mouseDown = true;
    // Mouse hover over BACK icon
    void OnMouseEnter()
    {
        forward.gameObject.GetComponent<SpriteRenderer>().sprite = forwardRed;
        hoverSFX.Play();
    }

    private void Start()
    {
        forward.SetActive(true);
        arrayPos = 0;
        mouseDown = true;
        tutorialBG.gameObject.GetComponent<SpriteRenderer>().sprite = tutorialScreens[0];
    }

    // Click on BACK arrow
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseDown)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit && hit.collider.gameObject.name == "Forward" && arrayPos >= tutorialScreens.Length - 1)
            {
                arrayPos = 0;
                SceneManager.LoadScene(sceneName: "HUB");
            }
            // Cycle through array of images
            else if (hit && hit.collider.gameObject.name == "Forward")
            {
                arrayPos += 1;
                tutorialBG.gameObject.GetComponent<SpriteRenderer>().sprite = tutorialScreens[arrayPos];
            }
            mouseDown = false;
        }
        else
        {
            mouseDown = true;
        }
    }

    // Mouse hover over nothing
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        forward.gameObject.GetComponent<SpriteRenderer>().sprite = forwardWhite;
    }
}
