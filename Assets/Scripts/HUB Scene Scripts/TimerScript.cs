using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class TimerScript : MonoBehaviour
{
    // Timer script that counts up
    public float TimeLeft; //in seconds
    public float TimeLimit; //in seconds
    public float TimePenalty;
    private bool TimerOn = true;
    public TMP_Text TimerText;

    //declare and assign the gameObj that has the script
    public GameObject EvidenceController;
    public GameObject LocationMouse;

    // TESTING TIMER VISUAL
    public Image timerVisual;

    // Ending
    private float randomEnding;

    // SFX
    public AudioSource badSFX;

    // Start is called before the first frame update
    void Start()
    {
        // timer starts automatically
        TimerOn = true;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            // Time limit (in seconds)
            if(TimeLeft > TimeLimit)
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
        
                    if(hit && hit.collider.gameObject.tag == "Penalty" && LocationMouse.GetComponent<LocationScript>().mouseDown == true)
                    {
                        TimeLeft -= TimePenalty; // Reduce by penalty

                        // TestIGNsdig
                        timerVisual.fillAmount -= 10f/120f ; // TimePenalty / Time Limit------------------

                        // SFX
                        badSFX.Play();
                    }
                }

                // Reduce the fill amount of the timer image
                timerVisual.fillAmount -= 1.0f/120.0f * Time.deltaTime;
                                            //Time left .0f ----------------------------------------------

            }
            else
            {
                // Turn off timer
                TimeLeft = 0;
                TimerOn = false;

                // Put fill amount of timer image to 0
                timerVisual.fillAmount = 0;

                // No evidence found
                if(EvidenceController.GetComponent<RemoveEvidenceScript>().lodgeAllFound == false &&
                   EvidenceController.GetComponent<RemoveEvidenceScript>().manorAllFound == false &&
                   EvidenceController.GetComponent<RemoveEvidenceScript>().farmAllFound == false &&
                   EvidenceController.GetComponent<RemoveEvidenceScript>().churchAllFound == false)
                {
                    randomEnding = Random.Range(1, 4);
                    if(randomEnding == 1)
                    {
                        SceneManager.LoadScene(sceneName: "EndingCultist");
                    }
                    else if (randomEnding == 2)
                    {
                        SceneManager.LoadScene(sceneName: "EndingHitman");
                    }
                    else if (randomEnding == 3)
                    {
                        SceneManager.LoadScene(sceneName: "EndingSK");
                    }
                    else if (randomEnding == 4)
                    {
                        SceneManager.LoadScene(sceneName: "EndingAlien");
                    }
                }
                else if(EvidenceController.GetComponent<RemoveEvidenceScript>().lodgeAllFound == false &&
                        EvidenceController.GetComponent<RemoveEvidenceScript>().manorAllFound == false &&
                        EvidenceController.GetComponent<RemoveEvidenceScript>().farmAllFound == false)
                {
                    randomEnding = Random.Range(1, 3);
                    if (randomEnding == 1)
                    {
                        SceneManager.LoadScene(sceneName: "EndingSK");
                    }
                    else if (randomEnding == 2)
                    {
                        SceneManager.LoadScene(sceneName: "EndingHitman");
                    }
                    else if (randomEnding == 3)
                    {
                        SceneManager.LoadScene(sceneName: "EndingAlien");
                    }
                }
                else if (EvidenceController.GetComponent<RemoveEvidenceScript>().lodgeAllFound == false &&
                         EvidenceController.GetComponent<RemoveEvidenceScript>().manorAllFound == false)
                {
                    randomEnding = Random.Range(1, 2);
                    if (randomEnding == 1)
                    {
                        SceneManager.LoadScene(sceneName: "EndingSK");
                    }
                    else if (randomEnding == 2)
                    {
                        SceneManager.LoadScene(sceneName: "EndingHitman");
                    }
                }
                // CHURCH NOT found
                else if (EvidenceController.GetComponent<RemoveEvidenceScript>().churchAllFound == false)
                {
                    SceneManager.LoadScene(sceneName: "EndingCultist");
                }
                // LODGE NOT found
                else if (EvidenceController.GetComponent<RemoveEvidenceScript>().lodgeAllFound == false)
                {
                    SceneManager.LoadScene(sceneName: "EndingHitman");
                }
                // MANOR NOT found
                else if (EvidenceController.GetComponent<RemoveEvidenceScript>().manorAllFound == false)
                {
                    SceneManager.LoadScene(sceneName: "EndingSK");
                }
                // FARM NOT found
                else if (EvidenceController.GetComponent<RemoveEvidenceScript>().farmAllFound == false)
                {
                    SceneManager.LoadScene(sceneName: "EndingAlien");
                }
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
}
