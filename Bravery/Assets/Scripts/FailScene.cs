using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScene : MonoBehaviour
{
    public void loadScene1()
    {
        SceneManager.LoadScene("Level2");
    }
    
    public void loadScene2()
    {
        SceneManager.LoadScene("LevelBoss");
    }

    public void getOut()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
}
