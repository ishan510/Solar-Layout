using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneToMainChanger : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("Main Scene"); // Loads the main scene in the build 
    }

    public void RoofChange()
    {
        SceneManager.LoadScene("Roof Scene");
    }
    public void PanelChange()
    {
        SceneManager.LoadScene("Solar Panel Scene");
    }
    public void AssessmentChange()
    {
        SceneManager.LoadScene("Assessment Scene");
    }
    
}
