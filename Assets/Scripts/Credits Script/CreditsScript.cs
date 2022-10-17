using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public GameObject back;
    public Sprite backWhite;
    public Sprite backRed;

    // Mouse hover over BACK icon
    void OnMouseOver()
    {
        back.gameObject.GetComponent<SpriteRenderer>().sprite = backRed;
    }

    // Click on BACK arrow
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            //START GAME
            if (hit && hit.collider.gameObject.name == "Back")
            {
                SceneManager.LoadScene(sceneName: "Title Screen");
            }
        }

    }

    // Mouse hover over nothing
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        back.gameObject.GetComponent<SpriteRenderer>().sprite = backWhite;
    }
}
