using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private int maxAmmo = 5;
    private float reloadTime = 1.5f;
    private int money = 0;
    private int gekauft = 0;
    private int highScore = 0;

    public void ResetAll()
    {
        PlayerPrefs.SetInt("MaxAmmo", maxAmmo);
        PlayerPrefs.SetFloat("ReloadTime", reloadTime);
        PlayerPrefs.SetInt("Gekauft", gekauft);
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.SetInt("HighScore", highScore);
    }
}