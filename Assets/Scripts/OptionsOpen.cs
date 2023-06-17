using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsOpen : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        GameObject optionscanva = GameObject.Find("OptionsMenu");
        var tempCanvas = optionscanva.GetComponent<Canvas>();
        tempCanvas.sortingOrder = 10;
        GameObject back = GameObject.Find("BackButton");
        var tempSprite = back.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = 10;

        GameObject start = GameObject.Find("BeginButton");
        tempSprite = start.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = -2;
        GameObject quit = GameObject.Find("QuitButton");
        tempSprite = quit.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = -2;
        GameObject options = GameObject.Find("OptionsButton");
        tempSprite = options.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = -2;
    }
}
