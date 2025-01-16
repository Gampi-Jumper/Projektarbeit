using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private int maxAmmo = 5;
    private float reloadTime = 1.5f;
    private int money = 0;
    private int gekauftGewehr = 0;
    private int gekauftMinigun = 0;
    private int highScore = 0;

    public void ResetAll()
    {
        PlayerPrefs.SetInt("MaxAmmo", maxAmmo);
        PlayerPrefs.SetFloat("ReloadTime", reloadTime);
        PlayerPrefs.SetInt("GekauftGewehr", gekauftGewehr);
        PlayerPrefs.SetInt("GekauftMinigun", gekauftMinigun);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}