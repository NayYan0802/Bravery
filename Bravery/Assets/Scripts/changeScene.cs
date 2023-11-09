using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeToBossScene();
        }
    }
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ChangeToBossScene()
    {
        SceneManager.LoadScene("LevelBoss");
    }
}
