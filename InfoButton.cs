using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infoPanel;
    public AudioSource clickAudio;
    public AudioSource closeAudio;

    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (highScore == 0)
        {
            infoPanel.SetActive(true);
        }
        else
        {
            infoPanel.SetActive(false);            
        }

    }

    public void OpenInfoPanel()
    {

        infoPanel.SetActive(true);
        clickAudio.Play();
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        closeAudio.Play();
    }
}
