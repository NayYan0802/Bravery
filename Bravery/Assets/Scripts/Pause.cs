using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject imageMenu;
    public GameObject MagicCanvas;

    public void OnPause()//点击“暂停”时执行此方法
    {
        Time.timeScale = 0;
        imageMenu.SetActive(true);
        MagicCanvas.SetActive(false);
    }

    public void OnResume()//点击“回到游戏”时执行此方法
    {
        Time.timeScale = 1f;
        imageMenu.SetActive(false);
        MagicCanvas.SetActive(true);
    }

    public void OnRestart()//点击“重新开始”时执行此方法
    {
        //Loading Scene0
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
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
