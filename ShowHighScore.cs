using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHighScore : MonoBehaviour
{
    private int highScore;

    public TextMeshProUGUI highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }
}
