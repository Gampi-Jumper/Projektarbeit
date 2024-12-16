using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    TextMeshProUGUI scoreText;

    public AudioSource killSound;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
        killSound.Play();
    }
}
