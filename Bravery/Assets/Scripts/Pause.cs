using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject imageMenu;
    public GameObject MagicCanvas;

    public void OnPause()//�������ͣ��ʱִ�д˷���
    {
        Time.timeScale = 0;
        imageMenu.SetActive(true);
        MagicCanvas.SetActive(false);
    }

    public void OnResume()//������ص���Ϸ��ʱִ�д˷���
    {
        Time.timeScale = 1f;
        imageMenu.SetActive(false);
        MagicCanvas.SetActive(true);
    }

    public void OnRestart()//��������¿�ʼ��ʱִ�д˷���
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
