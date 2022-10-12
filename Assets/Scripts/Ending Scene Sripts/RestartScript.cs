using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Click to return to main menu
        if (Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene (sceneName:"HUB");
        }
    }
}
