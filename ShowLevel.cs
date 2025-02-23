using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowLevel : MonoBehaviour
{
    private int level;
    private float progress;
    public Slider progressBar;

    public TextMeshProUGUI levelText;

    void Start()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        levelText.text = level.ToString();

        progress = PlayerPrefs.GetFloat("Progress", 0f);
        progressBar.value = progress;
    }
}