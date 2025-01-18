using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{
    private int money;

    public GameObject schlossGewehr;
    public GameObject schlossMinigun;

    public Image buttonPistole;
    public Image buttonGewehr;
    public Image buttonMinigun;

    private int currentGun;

    public AudioSource buttonSound;
    public AudioSource buySound;
    public AudioSource errorSound;

    private int gekauftGewehr;
    private int gekauftMinigun;

    void Awake()
    {
        buttonPistole.color = Color.green;
        buttonGewehr.color = Color.white;
        buttonMinigun.color = Color.white;
    }

    void Start()
    {
        currentGun = PlayerPrefs.GetInt("CurrentGun", 1);
        if(currentGun == 1)
        {
            buttonPistole.color = Color.green;
            buttonGewehr.color = Color.white;
            buttonMinigun.color = Color.white;
        }
        if(currentGun == 2)
        {
            buttonPistole.color = Color.white;
            buttonGewehr.color = Color.green;
            buttonMinigun.color = Color.white;
        }
        if(currentGun == 3)
        {
            buttonPistole.color = Color.white;
            buttonGewehr.color = Color.white;
            buttonMinigun.color = Color.green;
        }
        
        gekauftGewehr = PlayerPrefs.GetInt("GekauftGewehr", 0);
        if(gekauftGewehr == 1)
        {
            schlossGewehr.SetActive(false);
        }
        gekauftMinigun = PlayerPrefs.GetInt("GekauftMinigun", 0);
        if(gekauftMinigun == 1)
        {
            schlossMinigun.SetActive(false);
        }
    }


    public void SetPistole()
    {
        currentGun = 1;
        PlayerPrefs.SetInt("CurrentGun", currentGun);
        PlayerPrefs.Save();
        buttonPistole.color = Color.green;
        buttonGewehr.color = Color.white;
        buttonMinigun.color = Color.white;
        buttonSound.Play();
    }

    public void SetGewehr()
    {
        gekauftGewehr = PlayerPrefs.GetInt("GekauftGewehr", 0);
        if(gekauftGewehr == 1)
        {
            currentGun = 2;
            PlayerPrefs.SetInt("CurrentGun", currentGun);
            PlayerPrefs.Save();
            buttonPistole.color = Color.white;
            buttonGewehr.color = Color.green;
            buttonMinigun.color = Color.white;
            buttonSound.Play();
        }
        else
        {
            money = PlayerPrefs.GetInt("Money", 0);
            if(money >= 2000)
            {
                schlossGewehr.SetActive(false);
                money = money - 2000;
                PlayerPrefs.SetInt("Money", money);
                PlayerPrefs.Save();
                currentGun = 2;
                PlayerPrefs.SetInt("CurrentGun", currentGun);
                PlayerPrefs.Save();
                buttonPistole.color = Color.white;
                buttonGewehr.color = Color.green;
                buttonMinigun.color = Color.white;
                gekauftGewehr = 1;
                PlayerPrefs.SetInt("GekauftGewehr", gekauftGewehr);
                PlayerPrefs.Save();
                buySound.Play();
            }
            else
            {
                errorSound.Play();
            }   
        }
    }

    public void SetMinigun()
    {
        gekauftMinigun = PlayerPrefs.GetInt("GekauftMinigun", 0);
        if(gekauftMinigun == 1)
        {
            currentGun = 3;
            PlayerPrefs.SetInt("CurrentGun", currentGun);
            PlayerPrefs.Save();
            buttonPistole.color = Color.white;
            buttonGewehr.color = Color.white;
            buttonMinigun.color = Color.green;
            buttonSound.Play();
        }
        else
        {
            money = PlayerPrefs.GetInt("Money", 0);
            if(money >= 5000)
            {
                schlossMinigun.SetActive(false);
                money = money - 5000;
                PlayerPrefs.SetInt("Money", money);
                PlayerPrefs.Save();
                currentGun = 3;
                PlayerPrefs.SetInt("CurrentGun", currentGun);
                PlayerPrefs.Save();
                buttonPistole.color = Color.white;
                buttonGewehr.color = Color.white;
                buttonMinigun.color = Color.green;
                gekauftMinigun = 1;
                PlayerPrefs.SetInt("GekauftMinigun", gekauftMinigun);
                PlayerPrefs.Save();
                buySound.Play();
            }
            else
            {
                errorSound.Play();
            }   
        }
    }
}
