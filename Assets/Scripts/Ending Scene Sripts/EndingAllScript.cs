using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAllScript : MonoBehaviour
{
    public GameObject endingBG;
    public Sprite endingStart;
    public Sprite endingAll;

    public AudioSource clickSFX;

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
                endingBG.gameObject.GetComponent<SpriteRenderer>().sprite = endingAll;
                mouseDown = false;
                clickSFX.Play();
            }
            else if(endingBG.gameObject.GetComponent<SpriteRenderer>().sprite == endingAll && mouseDown == true)
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
