using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Slider progressBar;
    private int levelScore = 20;
    private int level = 1;
    private float levelMultiplier = 1.5f;
    private int baseThreshold = 20;

    private int score = 0;
    private int highScore;
    private int money;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI moneyText;

    public AudioSource killSound;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        UpdateLevel();

        level = PlayerPrefs.GetInt("Level", 1);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        money = PlayerPrefs.GetInt("Money", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        moneyText.text = money.ToString();
        levelText.text = level.ToString();
    }

    public void AddScore(int points)
    {
        AddLevelScore();

        score += points;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();

        money += points * 10;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = highScore.ToString();
        }

        scoreText.text = score.ToString();
        moneyText.text = money.ToString();
        killSound.Play();
    }

    public void AddLevelScore()
    {
        levelScore = PlayerPrefs.GetInt("LevelScore", 20);
        levelScore += 1;
        PlayerPrefs.SetInt("LevelScore", levelScore);
        PlayerPrefs.Save();
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        int newLevel = 0;
        int threshold = baseThreshold;
        int previousThreshold = 0;

        levelScore = PlayerPrefs.GetInt("LevelScore", 20);
        while(levelScore >= threshold)
        {
            newLevel++;
            previousThreshold = threshold;
            threshold = Mathf.RoundToInt(baseThreshold * Mathf.Pow(levelMultiplier, newLevel));
        }
        level = newLevel;
        levelText.text = level.ToString();
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();

        int scoreSinceLastLevel = levelScore - previousThreshold;
        int scoreToNextLevel = threshold - previousThreshold;
        float progress = (float)scoreSinceLastLevel / scoreToNextLevel;
        progressBar.value = progress;
        PlayerPrefs.SetFloat("Progress", progress);
        
        //Debug.Log("Score: " + levelScore + " | Level: " + level);
    }

    public void AddScoreGranate(int points)
    {
        score += points;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            highScoreText.text = highScore.ToString();
        }
    }
}
