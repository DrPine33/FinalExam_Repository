using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadExitScene()
    {
        SceneManager.LoadScene("Exit");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting the game");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
