using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoveEvidenceScript : MonoBehaviour
{
    // Script to remove evidence in different locations
    //MANOR LOCATION---------------------------------------------------
    public GameObject[] manorLocationE; // Evidence in MANOR location
    public GameObject[] mapManorE; // Evidence PROGRESS for manor in main MAP
    private int manorEvidenceBar; //Location PROGRESS bar
    public bool manorAllFound;

    //FARM LOCATION---------------------------------------------------
    public GameObject[] farmLocationE; // Evidence in FARM location
    public GameObject[] mapFarmE; // Evidence PROGRESS for farm in main MAP
    private int farmEvidenceBar; //Location PROGRESS bar
    public bool farmAllFound;

    //CHURCH LOCATION---------------------------------------------------
    public GameObject[] churchLocationE; // Evidence in CHURCH location
    public GameObject[] mapChurchE; // Evidence PROGRESS for church in main MAP
    private int churchEvidenceBar; //Location PROGRESS bar
    public bool churchAllFound;

    //LODGE LOCATION---------------------------------------------------
    public GameObject[] lodgeLocationE; // Evidence in LODGE location
    public GameObject[] mapLodgeE; // Evidence PROGRESS for LODGE in main MAP
    private int lodgeEvidenceBar; //Location PROGRESS bar
    public bool lodgeAllFound;


    // Start is called before the first frame update
    void Start()
    {
        //MANOR tag-----------------------------------------------------------
        gameObject.tag = "ManorE";
        manorEvidenceBar = manorLocationE.Length;

        //FARM tag-----------------------------------------------------------
        gameObject.tag = "FarmE";
        farmEvidenceBar = farmLocationE.Length;

        //CHURCH tag-----------------------------------------------------------
        gameObject.tag = "ChurchE";
        churchEvidenceBar = churchLocationE.Length;

        //LODGE tag-----------------------------------------------------------
        gameObject.tag = "LodgeE";
        lodgeEvidenceBar = lodgeLocationE.Length;

    }

    // Update is called once per frame
    void Update()
    {
        // Click function
        if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            //Clicks on collider area
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // Clicks MANOR evidence--------------------------- 
            if (hit && hit.collider.gameObject.tag == "ManorE")
            {
                Destroy(hit.transform.gameObject);
                ManorEvidenceFound(1);
            }

            // Clicks FARM evidence--------------------------
           if (hit && hit.collider.gameObject.tag == "FarmE")
            {
                Destroy(hit.transform.gameObject);
                FarmEvidenceFound(1);
            }

            // Clicks CHURCH evidence------------------------
           if (hit && hit.collider.gameObject.tag == "ChurchE")
            {
                Destroy(hit.transform.gameObject);
                ChurchEvidenceFound(1);
            }

            // Clicks LODGE evidence------------------------
           if (hit && hit.collider.gameObject.tag == "LodgeE")
            {
                Destroy(hit.transform.gameObject);
                LodgeEvidenceFound(1);
            }

        }

        // No more evidence
        if(manorAllFound && farmAllFound && churchAllFound && lodgeAllFound)
        {
            // Found all the evidence
            SceneManager.LoadScene (sceneName:"Win");
        }
    }

    //Found evidence in MANOR location---------------------------
    public void ManorEvidenceFound(int d)
    {
        if (manorEvidenceBar >= 1)
        {
            //Map bar
            manorEvidenceBar -= d; //1-1=0
            Destroy(mapManorE[manorEvidenceBar].gameObject);
            if(manorEvidenceBar < 1)
            {
                manorAllFound = true;
            }

        }
    }

    //Found evidence in FARM location---------------------------
    public void FarmEvidenceFound(int d)
    {
        if (farmEvidenceBar >= 1)
        {
            //Map bar
            farmEvidenceBar -= d; //1-1=0
            Destroy(mapFarmE[farmEvidenceBar].gameObject);
            if(farmEvidenceBar < 1)
            {
                farmAllFound = true;
            }

        }
    }

    //Found evidence in CHURCH location---------------------------
    public void ChurchEvidenceFound(int d)
    {
        if (churchEvidenceBar >= 1)
        {
            //Map bar
            churchEvidenceBar -= d; //1-1=0
            Destroy(mapChurchE[churchEvidenceBar].gameObject);
            if(churchEvidenceBar < 1)
            {
                churchAllFound = true;
            }

        }
    }

    //Found evidence in LODGE location---------------------------
    public void LodgeEvidenceFound(int d)
    {
        if (lodgeEvidenceBar >= 1)
        {
            //Map bar
            lodgeEvidenceBar -= d; //1-1=0
            Destroy(mapLodgeE[lodgeEvidenceBar].gameObject);
            if(lodgeEvidenceBar < 1)
            {
                lodgeAllFound = true;
            }

        }
    }
}