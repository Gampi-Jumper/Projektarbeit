using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infoPanel;
    public AudioSource clickAudio;
    public AudioSource closeAudio;

    void Start()
    {
        infoPanel.SetActive(false);
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
