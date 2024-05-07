using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SendScoresScript : MonoBehaviour
{
    public Text NameText;
    public Text ScoreText;

    string playerName;
    int score;
    void Start()
    {
 
    }

    public void SaveScore(string textInField)
    {
        playerName = NameText.text;

        int.TryParse(ScoreText.text, out score);


        StartCoroutine(ConnectToPHP());
    } 

    IEnumerator ConnectToPHP()
    {
        string url = "http://localhost/Rineheat/addscore.php";
        url += "?name=" + playerName + "&score=" + score; 
        WWW www = new WWW(url);
        yield return www;
        print("DB updated");
    }
}
