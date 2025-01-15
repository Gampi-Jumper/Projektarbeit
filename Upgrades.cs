using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrades : MonoBehaviour
{
    private float reloadTime;
    private int maxAmmo;
    private int money;

    public TextMeshProUGUI munitionText;
    public TextMeshProUGUI munitionPreisText;

    public TextMeshProUGUI reloadText;
    public TextMeshProUGUI reloadPreisText;

    public AudioSource buySound;
    public AudioSource errorSound;

    void Start()
    {
        maxAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
        if(maxAmmo == 10)
        {
            munitionPreisText.text = "MAX";
        }
        munitionText.text = maxAmmo.ToString();
        
        reloadTime = PlayerPrefs.GetFloat("ReloadTime", 1.5f);
        if(reloadTime == 0.5f)
        {
            reloadPreisText.text = "MAX";
        }
        reloadText.text = reloadTime.ToString();

        money = PlayerPrefs.GetInt("Money", 0);
    }

    public void UpgradeMunition()
    {
        maxAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
        if(maxAmmo >= 10)
        {
            errorSound.Play();
        }
        else
        {
            money = PlayerPrefs.GetInt("Money", 0);
            if(money >= 30)
            {
                money = money - 30;
                PlayerPrefs.SetInt("Money", money);
                PlayerPrefs.Save();
                maxAmmo = PlayerPrefs.GetInt("MaxAmmo", 5);
                maxAmmo = maxAmmo + 1;
                PlayerPrefs.SetInt("MaxAmmo", maxAmmo);
                PlayerPrefs.Save();
                munitionText.text = maxAmmo.ToString();
                buySound.Play();
                if(maxAmmo == 10)
                {
                    munitionPreisText.text = "MAX";
                }
            }
            else
            {
                errorSound.Play();
            }
        }
    }

    public void UpgradeReload()
    {
        reloadTime = PlayerPrefs.GetFloat("ReloadTime", 1.5f);
        if(reloadTime <= 0.5f)
        {
            errorSound.Play();
        }
        else
        {
            money = PlayerPrefs.GetInt("Money", 0);
            if(money >= 50)
            {
                money = money - 50;
                PlayerPrefs.SetInt("Money", money);
                PlayerPrefs.Save();
                reloadTime = PlayerPrefs.GetFloat("ReloadTime", 1.5f);
                reloadTime = reloadTime - 0.5f;
                PlayerPrefs.SetFloat("ReloadTime", reloadTime);
                PlayerPrefs.Save();
                reloadText.text = reloadTime.ToString();
                buySound.Play();
                if(reloadTime == 0.5f)
                {
                    reloadPreisText.text = "MAX";
                }
            }
            else
            {
                errorSound.Play();
            }
        }
    }
}
