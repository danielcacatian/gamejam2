using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    // Church journal -----------------------------------
        // Lines
        public GameObject churchNecklaceLine;
        public GameObject churchPoisonLine;
        public GameObject churchCrackLine;
        public GameObject churchKnivesLine;
        public GameObject churchPostersLine;
        // Evidences
        public GameObject churchNecklace;
        public GameObject churchPoison;
        public GameObject churchCrack;
        public GameObject churchKnives;
        public GameObject churchPosters;

    // Start is called before the first frame update
    void Start()
    {
        //CHURCH line deactivation ----------------------
        churchNecklaceLine.SetActive(false);
        churchPoisonLine.SetActive(false);
        churchCrackLine.SetActive(false);
        churchKnivesLine.SetActive(false);
        churchPostersLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // CHURCH journal lines --------------------------
        // Necklace is removed
        if (churchNecklace.gameObject == null)
        {
            churchNecklaceLine.SetActive(true);
        }
        // Poison is removed
        if (churchPoison.gameObject == null)
        {
            churchPoisonLine.SetActive(true);
        }
        // Crack is removed
        if (churchCrack.gameObject == null)
        {
            churchCrackLine.SetActive(true);
        }
        // Knives is removed
        if (churchKnives.gameObject == null)
        {
            churchKnivesLine.SetActive(true);
        }
        // Posters is removed
        if (churchPosters.gameObject == null)
        {
            churchPostersLine.SetActive(true);
        }
    }
}
