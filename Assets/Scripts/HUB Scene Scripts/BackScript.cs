using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
// Script for the back button to switch back to map camera
    public Camera[] cameras;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
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
    }
}
