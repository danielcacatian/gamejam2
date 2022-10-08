using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEvidenceScript : MonoBehaviour
{
    public GameObject[] evidences;
    public GameObject[] homeEvidences;
    private int evidencebar; //Location area bar
    private bool allfound;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Evidence";
        evidencebar = evidences.Length;
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
            if (hit && hit.collider.gameObject.tag == "Evidence")
            {
                Debug.Log("removed");
                Destroy(hit.transform.gameObject);
                EvidenceFound(1);

            }
        }

        // No more evidence
        if(allfound)
        {
            Debug.Log("No more evidence");
        }
    }

    public void EvidenceFound(int d)
    {
        if (evidencebar >= 1)
        {
            Debug.Log("Found");
            //Map bar
            evidencebar -= d; //1-1=0
            Destroy(evidences[evidencebar].gameObject);
            Destroy(homeEvidences[evidencebar].gameObject);
            if(evidencebar < 1)
            {
                allfound = true;
            }

        }
    }
}