using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
     public static int _lastSceneIndex;

    public void loadSceneByIndex(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void loadSceneByName(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
    public static  void goToGameOverScene() {
        //store the index of last scene
        _lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //load scene gameover
        SceneManager.LoadSceneAsync("GameOver");
    }

    public static void restartLastScene() {
        SceneManager.LoadSceneAsync(_lastSceneIndex);
    }

    //this method is called when user click the continue button in Game Menu
    public void ContinueButtonClick()
    {
        try
        {
            JsonHandler handler = gameObject.AddComponent<JsonHandler>();
            handler.Load();
            loadSceneByName(handler.data.sceneName);
        } catch (Exception ex)
        {
            //if can't find file -> go to Scene 1 (default)
            loadSceneByName("Scene1");
        }
    }
}
