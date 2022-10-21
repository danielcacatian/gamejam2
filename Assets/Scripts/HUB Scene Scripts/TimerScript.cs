using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{
    // Timer script that counts up
    public float TimeLeft; //in seconds
    public float TimeLimit; //in seconds
    public float TimePenalty;
    public bool TimerOn = true;
    public TMP_Text TimerText;

    //declare and assign the gameObj that has the script
    public GameObject EvidenceController;

    // TESTING TIMER VISUAL
    public Image timerVisual;

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

                // Time penalty --------------------------------------------------------
                if (Input.GetMouseButtonDown(0) && Time.timeScale == 1)
                {
                    // collider
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
                    if(hit && hit.collider.gameObject.tag == "Penalty")
                    {
                        TimeLeft -= TimePenalty; // Reduce by penalty

                        // TestIGNsdig
                        timerVisual.fillAmount -= 10f/120f ; // TimePenalty / Time Limit------------------
                    }
                }

                Debug.Log(timerVisual.fillAmount);

                // Reduce the fill amount of the timer image
                timerVisual.fillAmount -= 1.0f/120.0f * Time.deltaTime;
                                            //Time left .0f ----------------------------------------------

                // Found all evidence
                allEvidenceFound();

            }
            else
            {
                // Turn off timer
                TimeLeft = 0;
                TimerOn = false;

                // Put fill amount of timer image to 0
                timerVisual.fillAmount = 0;

                // Bad ending
                SceneManager.LoadScene (sceneName:"Game Over");

            }
        }
    }

    // Timer goes down
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
        if(EvidenceController.GetComponent<RemoveEvidenceScript>().churchAllFound)
        {
            // You found all the evidence
            SceneManager.LoadScene (sceneName:"Win");
        }
    }
}
