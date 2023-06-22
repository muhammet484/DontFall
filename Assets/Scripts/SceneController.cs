using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//note: i didn't make the functions static to be useable with UI buttons
public class SceneController : MonoBehaviour
{
    public void OpenCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenLastScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene > 0)
            SceneManager.LoadScene(currentScene - 1);
    }
    public void OpenNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(currentScene + 1);
    }
    public void OpenSceneAtIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void OpenSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //debug purpose
    public void UIPrint(string something)
    {
        print(something);
    }

    int __count = 1;
    public void UIPrintCount()
    {
        print(__count++);
    }
}
