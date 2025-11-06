using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    private void LoadARSceneWithBackground(string backgroundName)
    {
        PlayerPrefs.SetString("SelectedBackground", backgroundName);
        Debug.Log($"Loading AR scene with {backgroundName}");
        SceneManager.LoadScene("arScene");
    }

    public void OnButton1Click()
    {
        LoadARSceneWithBackground("map1_background1");
    }

    public void OnButton2Click()
    {
        LoadARSceneWithBackground("map2_background2");
    }

    public void OnBtnExitClick()
    {
        Debug.Log("Exiting to start scene");
        SceneManager.LoadScene("startScene");
    }
}
