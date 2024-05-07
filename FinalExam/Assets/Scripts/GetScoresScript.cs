using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetScoresScript : MonoBehaviour
{
    private string highscoreURL = "http://localhost/Rineheat/display.php";

    private void Start()
    {
        StartCoroutine(GetScores());
    }
    IEnumerator GetScores()
    {
        WWW www = new WWW(highscoreURL);
        yield return www;
        string result = www.text;
        print("data received" + result);
        GameObject.Find("HighScoresText").GetComponent<Text>().text = result;
    }
}
