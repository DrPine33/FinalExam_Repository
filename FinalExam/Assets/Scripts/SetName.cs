using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetName : MonoBehaviour
{
    public InputField nameInputField;
    // Start is called before the first frame update
    void Start()
    {
        string playerName = PlayerPrefs.GetString("Player", "");
        nameInputField.text = playerName;

        if (SceneManager.GetActiveScene().name == "Game")
        {
            string playerText = PlayerPrefs.GetString("Player", "");
            nameInputField.text = playerText;
        }

        if(SceneManager.GetActiveScene().name == "Intro")
        {
            PlayerPrefs.DeleteKey("Player");
            nameInputField.text = "";
        }
    }

    public void SavePlayerName()
    {
        PlayerPrefs.SetString("Player", nameInputField.text);
        PlayerPrefs.Save();
    }
}
