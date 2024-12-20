using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    private int score;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = score.ToString();
    }
}
