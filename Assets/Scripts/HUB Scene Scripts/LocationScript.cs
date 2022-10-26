using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocationScript : MonoBehaviour
{
    // Script that allows the user to switch to different locations when clicking on them
    public Camera[] cameras;

    // Map sprites
    public GameObject map;
    public Sprite mapOG;
    public Sprite mapLodge;
    public Sprite mapManor;
    public Sprite mapFarm;
    public Sprite mapChurch;

    // SFX
    public AudioSource locationSFX;
    public AudioSource clickSFX;

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
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
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
                //SFX
                clickSFX.Play();
            }
            //Brings you to FARM location
            if (hit && hit.collider.gameObject.name == "Farm")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = true; // Enable FARM cam
                cameras[3].GetComponent<Camera>().enabled = false;
                cameras[4].GetComponent<Camera>().enabled = false;
                //SFX
                clickSFX.Play();
            }
            //Brings you to CHURCH location
            if (hit && hit.collider.gameObject.name == "Church")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = false;
                cameras[3].GetComponent<Camera>().enabled = true; // Enable CHURCH cam
                cameras[4].GetComponent<Camera>().enabled = false;
                //SFX
                clickSFX.Play();
            }
            //Brings you to LODGE location
            if (hit && hit.collider.gameObject.name == "Lodge")
            {
                cameras[0].GetComponent<Camera>().enabled = false;
                cameras[1].GetComponent<Camera>().enabled = false;
                cameras[2].GetComponent<Camera>().enabled = false;
                cameras[3].GetComponent<Camera>().enabled = false;
                cameras[4].GetComponent<Camera>().enabled = true; // Enable LODGE cam
                //SFX
                clickSFX.Play();
            }
        }
    }

    // Mouse hover over certain locations
    void OnMouseEnter()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        //Hovers on collider area
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if(Time.timeScale == 1)
        {
            // Hover over manor
            if (hit && hit.collider.gameObject.name == "Manor" || hit.collider.gameObject.name == "Serial Killer PFP")
            {
                map.gameObject.GetComponent<SpriteRenderer>().sprite = mapManor;
                locationSFX.Play();
            }

            // Hover over lodge
            else if (hit && hit.collider.gameObject.name == "Lodge" || hit.collider.gameObject.name == "Hitman PFP")
            {
                map.gameObject.GetComponent<SpriteRenderer>().sprite = mapLodge;
                locationSFX.Play();
            }

            // Hover over church
            else if (hit && hit.collider.gameObject.name == "Church" || hit.collider.gameObject.name == "Cultist PFP")
            {
                map.gameObject.GetComponent<SpriteRenderer>().sprite = mapChurch;
                locationSFX.Play();
            }
        }
    }

    // Mouse hover over nothing
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        map.gameObject.GetComponent<SpriteRenderer>().sprite = mapOG;
    }
}
