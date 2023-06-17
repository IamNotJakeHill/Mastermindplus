using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour

{
    public string targetSceneName; // Name of the scene to switch to
    public Slider rowsSlider;

    private void OnMouseDown()
    {
        setNumberOfRows();
        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }

    public void setNumberOfRows()
    {
        OptionsData.rowsNumber = rowsSlider.value;
    }
}