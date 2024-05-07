using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{
    public static ScoreControl instance; // Singleton instance

    public int score = 0; // Current player score
    public Text scoreText; // Reference to the UI text element to display score
    public SendScoresScript sendScoreScript;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        sendScoreScript = GetComponent<SendScoresScript>();
    }

    // Method to add points to the player's score
    public void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreUI();

        if(score == 5)
        {
            sendScoreScript.SaveScore("");
            SceneManager.LoadScene("Exit");
        }
    }

    public void ButtonAddPoints(int pointToAdd)
    {
        score += pointToAdd;
        UpdateScoreUI();
        if (score == 1)
        { sendScoreScript.SaveScore(""); }
        if(score == 2)
        { sendScoreScript.SaveScore(""); }
        if(score == 3)
        { sendScoreScript.SaveScore(""); }
        if(score == 4)
        { sendScoreScript.SaveScore(""); }
    }

    // Method to update the score UI text
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}
