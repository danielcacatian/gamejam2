using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
    // Script for the back button to switch back to map camera
    public Camera[] cameras;

    // Back arrow sprite
    public GameObject back;
    public Sprite backWhite;
    public Sprite backRed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            //Clicks on collider area
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit && hit.collider.gameObject.name == "Back") 
            {
                //Go back to main camera
                cameras[0].GetComponent<Camera>().enabled = true;

                // Disable all other camera locations
                for(int i=1; i < cameras.Length; i++) 
                {
                    cameras[i].GetComponent<Camera>().enabled = false;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            //Go back to main camera
            cameras[0].GetComponent<Camera>().enabled = true;

            // Disable all other camera locations
            for (int i = 1; i < cameras.Length; i++)
            {
                cameras[i].GetComponent<Camera>().enabled = false;
            }
        }
    }

    // Mouse hover over BACK icon
    void OnMouseOver()
    {
        back.gameObject.GetComponent<SpriteRenderer>().sprite = backRed;
    }

    // Mouse hover over nothing
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        back.gameObject.GetComponent<SpriteRenderer>().sprite = backWhite;
    }
}
