using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
    public void back()
    {
        GameObject optionscanva = GameObject.Find("OptionsMenu");
        var tempCanvas = optionscanva.GetComponent<Canvas>();
        tempCanvas.sortingOrder = -2;
        GameObject back = GameObject.Find("BackButton");
        var tempSprite = back.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = -2;

        GameObject start = GameObject.Find("BeginButton");
        tempSprite = start.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = 10;
        GameObject quit = GameObject.Find("QuitButton");
        tempSprite = quit.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = 10;
        GameObject options = GameObject.Find("OptionsButton");
        tempSprite = options.GetComponent<SpriteRenderer>();
        tempSprite.sortingOrder = 10;
    }
}
