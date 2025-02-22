using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    private int money;
    private int levelScore;

    public void ResetAll()
    {
        PlayerPrefs.SetInt("Granates", 0);
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("LevelScore", 20);
        PlayerPrefs.SetInt("MaxAmmo", 5);
        PlayerPrefs.SetFloat("ReloadTime", 1.5f);
        PlayerPrefs.SetInt("GekauftGewehr", 0);
        PlayerPrefs.SetInt("GekauftMinigun", 0);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.Save();
    }

    public void AddAll()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        money = money + 1000;
        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();

        levelScore = PlayerPrefs.GetInt("LevelScore", 20);
        levelScore = levelScore + 100;
        PlayerPrefs.SetInt("LevelScore", levelScore);
        PlayerPrefs.Save();
    }
}