using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
        // Manor journal -----------------------------------
        // Lines
        public GameObject manorMopLine;
        public GameObject manorShrineLine;
        public GameObject manorLockLine;
        public GameObject manorBodyLine;
        public GameObject manorAxeLine;
        // Evidences
        public GameObject manorMop;
        public GameObject manorShrine;
        public GameObject manorLock;
        public GameObject manorBody;
        public GameObject manorAxe;
        // Lodge journal -----------------------------------
        // Lines
        public GameObject lodgeGunLine;
        public GameObject lodgeDisguisesLine;
        public GameObject lodgeCutleryLine;
        public GameObject lodgeHitlistLine;
        public GameObject lodgeSuitLine;
        // Evidences
        public GameObject lodgeGun;
        public GameObject lodgeDisguises;
        public GameObject lodgeCutlery;
        public GameObject lodgeHitlist;
        public GameObject lodgeSuit;
    // Church journal -----------------------------------
        // Lines
        public GameObject churchGobletLine;
        public GameObject churchPoisonLine;
        public GameObject churchCrackLine;
        public GameObject churchKnivesLine;
        public GameObject churchPostersLine;
        // Evidences
        public GameObject churchGoblet;
        public GameObject churchPoison;
        public GameObject churchCrack;
        public GameObject churchKnives;
        public GameObject churchPosters;

    // Start is called before the first frame update
    void Start()
    {
        //MANOR line deactivation ----------------------
        manorMopLine.SetActive(false);
        manorShrineLine.SetActive(false);
        manorLockLine.SetActive(false);
        manorBodyLine.SetActive(false);
        manorAxeLine.SetActive(false);

        //LODGE line deactivation ----------------------
        lodgeGunLine.SetActive(false);
        lodgeDisguisesLine.SetActive(false);
        lodgeCutleryLine.SetActive(false);
        lodgeHitlistLine.SetActive(false);
        lodgeSuitLine.SetActive(false);

        //CHURCH line deactivation ----------------------
        churchGobletLine.SetActive(false);
        churchPoisonLine.SetActive(false);
        churchCrackLine.SetActive(false);
        churchKnivesLine.SetActive(false);
        churchPostersLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // MANOR journal lines --------------------------
        if (manorMop.gameObject == null)
        {
            manorMopLine.SetActive(true);
        }
        if (manorShrine.gameObject == null)
        {
            manorShrineLine.SetActive(true);
        }
        if (manorLock.gameObject == null)
        {
            manorLockLine.SetActive(true);
        }
        if (manorBody.gameObject == null)
        {
            manorBodyLine.SetActive(true);
        }
        if (manorAxe.gameObject == null)
        {
            manorAxeLine.SetActive(true);
        }

        // LODGE journal lines --------------------------
        if (lodgeGun.gameObject == null)
        {
            lodgeGunLine.SetActive(true);
        }
        if (lodgeDisguises.gameObject == null)
        {
            lodgeDisguisesLine.SetActive(true);
        }
        if (lodgeCutlery.gameObject == null)
        {
            lodgeCutleryLine.SetActive(true);
        }
        if (lodgeHitlist.gameObject == null)
        {
            lodgeHitlistLine.SetActive(true);
        }
        if (lodgeSuit.gameObject == null)
        {
            lodgeSuitLine.SetActive(true);
        }

        // CHURCH journal lines --------------------------
        // Necklace is removed
        if (churchGoblet.gameObject == null)
        {
            churchGobletLine.SetActive(true);
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
