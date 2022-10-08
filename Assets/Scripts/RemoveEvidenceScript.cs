using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEvidenceScript : MonoBehaviour
{
// Script to remove evidence in different locations
    //MANOR LOCATION---------------------------------------------------
    public GameObject[] manorLocationE; // Evidence in manor location
    public GameObject[] mapManorE; // Evidence PROGRESS for manor in main MAP
    private int manorEvidenceBar; //Location PROGRESS bar
    private bool manorAllFound;

    //FARM LOCATION---------------------------------------------------
    public GameObject[] farmLocationE; // Evidence in farm location
    public GameObject[] mapFarmE; // Evidence PROGRESS for farm in main MAP
    private int farmEvidenceBar; //Location PROGRESS bar
    private bool farmAllFound;


    // Start is called before the first frame update
    void Start()
    {
        //MANOR tag
        gameObject.tag = "ManorE";
        manorEvidenceBar = manorLocationE.Length;

        //FARM tag
        gameObject.tag = "FarmE";
        farmEvidenceBar = farmLocationE.Length;

    }

    // Update is called once per frame
    void Update()
    {
        // Click function
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            //Clicks on collider area
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            // Clicks MANOR evidence
            if (hit && hit.collider.gameObject.tag == "ManorE")
            {
                Destroy(hit.transform.gameObject);
                ManorEvidenceFound(1);
            }

            // Clicks FARM evidence
           if (hit && hit.collider.gameObject.tag == "FarmE")
            {
                Destroy(hit.transform.gameObject);
                FarmEvidenceFound(1);
            }

        }

        // No more evidence
        if(manorAllFound && farmAllFound)
        {
            Debug.Log("No more evidence");
        }
    }

    //Found evidence in MANOR location
    public void ManorEvidenceFound(int d)
    {
        if (manorEvidenceBar >= 1)
        {
            //Map bar
            manorEvidenceBar -= d; //1-1=0
            Destroy(manorLocationE[manorEvidenceBar].gameObject);
            Destroy(mapManorE[manorEvidenceBar].gameObject);
            if(manorEvidenceBar < 1)
            {
                manorAllFound = true;
            }

        }
    }

    //Found evidence in FARM location
    public void FarmEvidenceFound(int d)
    {
        if (farmEvidenceBar >= 1)
        {
            //Map bar
            farmEvidenceBar -= d; //1-1=0
            Destroy(farmLocationE[farmEvidenceBar].gameObject);
            Destroy(mapFarmE[farmEvidenceBar].gameObject);
            if(farmEvidenceBar < 1)
            {
                farmAllFound = true;
            }

        }
    }
}