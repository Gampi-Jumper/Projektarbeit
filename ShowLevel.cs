using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLevel : MonoBehaviour
{
    private int level;

    public TextMeshProUGUI levelText;

    void Start()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        levelText.text = level.ToString();
    }
}