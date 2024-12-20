using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    private int highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public AudioSource killSound;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = highScore.ToString();
        }

        scoreText.text = score.ToString();
        killSound.Play();
    }
}
