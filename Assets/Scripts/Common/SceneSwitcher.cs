using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
     static int _lastSceneIndex;

    public void loadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void loadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
    public static void goToGameOverScene() {
        //store the index of last scene
        _lastSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //load scene gameover
        SceneManager.LoadScene("GameOver");
    }

    public static void restartLastScene() {
        SceneManager.LoadScene(_lastSceneIndex);
    }
}
