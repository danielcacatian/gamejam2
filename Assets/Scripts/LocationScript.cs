using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationScript : MonoBehaviour
{
    public Camera[] cameras;
    public GameObject loc1;

    // Start is called before the first frame update
    void Start()
    {
        cameras[0].GetComponent<Camera>().enabled = true;
        cameras[1].GetComponent<Camera>().enabled = false;
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
            
            if (hit && hit.collider.gameObject.name == "Location1")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = true;
            }
        }
    }
}
