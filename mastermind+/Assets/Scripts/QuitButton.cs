using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{

    private void OnMouseDown()
    {
        Debug.Log("i d quit if i could");
        Application.Quit();
       
    }
}
