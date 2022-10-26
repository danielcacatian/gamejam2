using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAlienScript : MonoBehaviour
{
    public GameObject endingBG;
    public Sprite endingStart;
    public Sprite endingAlien;

    public AudioSource badSFX;

    private bool mouseDown = true;

    // Start is called before the first frame update
    void Start()
    {
        endingBG.gameObject.GetComponent<SpriteRenderer>().sprite = endingStart;
        mouseDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Click to return to main menu
        if (Input.GetMouseButtonDown(0) && mouseDown == true)
        {
            if (endingBG.gameObject.GetComponent<SpriteRenderer>().sprite == endingStart && mouseDown == true)
            {
                endingBG.gameObject.GetComponent<SpriteRenderer>().sprite = endingAlien;
                mouseDown = false;
                badSFX.Play();
            }
            else if(endingBG.gameObject.GetComponent<SpriteRenderer>().sprite == endingAlien && mouseDown == true)
            {
                SceneManager.LoadScene(sceneName: "Title Screen");
            }

        }
        else
        {
            mouseDown = true;
        }
    }
}
