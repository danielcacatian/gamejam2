using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerScript : MonoBehaviour
{
    // Timer script that counts up
    public float TimeLeft; //in seconds
    public float TimeLimit; //in seconds
    public bool TimerOn = true;
    public TMP_Text TimerText;

    //declare and assign the gameObj that has the script
    public GameObject EvidenceController;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            // Time limit (in seconds)
            if(TimeLeft > TimeLimit) // Ends at 12mins
            {
                // Update timer
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);

                // Found all evidence
                // allEvidenceFound();

            }
            else
            {
                // Turn off timer
                TimeLeft = 0;
                TimerOn = false;

                // Bad ending
                SceneManager.LoadScene (sceneName:"Game Over");

            }
        }
    }

    // Timer goes up
    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //In your function
    void allEvidenceFound()
    {
        if(EvidenceController.GetComponent<RemoveEvidenceScript>().manorAllFound)
        {
            // You found all the evidence
            SceneManager.LoadScene (sceneName:"Win");
        }
    }
}
