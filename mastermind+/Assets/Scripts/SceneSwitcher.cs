using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour

{
    public string targetSceneName; // Name of the scene to switch to

    private void OnMouseDown()
    {
        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }
}