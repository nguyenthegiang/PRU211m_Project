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
}
