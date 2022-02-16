using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public void loadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void loadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
