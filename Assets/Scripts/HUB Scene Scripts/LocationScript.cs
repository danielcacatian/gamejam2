using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationScript : MonoBehaviour
{
// Script that allows the user to switch to different locations when clicking on them
    public Camera[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        //Disable all cameras except the map
        cameras[0].GetComponent<Camera>().enabled = true;
        for(int i=1; i < cameras.Length; i++) 
            {
                cameras[i].GetComponent<Camera>().enabled = false;
            }
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
            
            //Brings you to MANOR location
            if (hit && hit.collider.gameObject.name == "Manor")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = true; // Enable MANOR cam
                cameras[2].GetComponent<Camera>().enabled = false;
                cameras[3].GetComponent<Camera>().enabled = false;
                cameras[4].GetComponent<Camera>().enabled = false;
            }
            //Brings you to FARM location
            if (hit && hit.collider.gameObject.name == "Farm")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = true; // Enable FARM cam
                cameras[3].GetComponent<Camera>().enabled = false;
                cameras[4].GetComponent<Camera>().enabled = false;
            }
            //Brings you to CHURCH location
            if (hit && hit.collider.gameObject.name == "Church")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = false;
                cameras[3].GetComponent<Camera>().enabled = true; // Enable CHURCH cam
                cameras[4].GetComponent<Camera>().enabled = false;
            }
            //Brings you to LODGE location
            if (hit && hit.collider.gameObject.name == "Lodge")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = false;
                cameras[3].GetComponent<Camera>().enabled = false;
                cameras[4].GetComponent<Camera>().enabled = true; // Enable LODGE cam
            }
        }
    }
}
