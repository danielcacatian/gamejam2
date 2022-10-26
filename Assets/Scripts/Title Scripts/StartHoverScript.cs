using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartHoverScript : MonoBehaviour
{
    public GameObject titleScreen;
    public Sprite title;
    public Sprite start;

    //SFX
    public AudioSource hoverSFX;

    // Mouse hover over START
    void OnMouseEnter()
    {
        titleScreen.gameObject.GetComponent<SpriteRenderer>().sprite = start;
        hoverSFX.Play();
    }

    // Click on START
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            //START GAME
            if (hit && hit.collider.gameObject.name == "Start")
            {
                SceneManager.LoadScene(sceneName: "Tutorial");
            }
        }

    }

    // Mouse hover over nothing
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        titleScreen.gameObject.GetComponent<SpriteRenderer>().sprite = title;
    }
}
