using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guns : MonoBehaviour
{
    private int money;

    public GameObject schloss;

    public Image buttonPistole;
    public Image buttonGewehr;

    private int currentGun;

    public AudioSource buttonSound;
    public AudioSource buySound;
    public AudioSource errorSound;

    private int gekauft;

    void Awake()
    {
        buttonPistole.color = Color.green;
        buttonGewehr.color = Color.white;
    }

    void Start()
    {
        currentGun = PlayerPrefs.GetInt("CurrentGun", 1);
        if(currentGun == 1)
        {
            buttonPistole.color = Color.green;
            buttonGewehr.color = Color.white;
        }
        
        if(currentGun == 2)
        {
            buttonPistole.color = Color.white;
            buttonGewehr.color = Color.green;
        }
        
        gekauft = PlayerPrefs.GetInt("Gekauft", 0);
        if(gekauft == 1)
        {
            schloss.SetActive(false);
        }
    }


    public void SetPistole()
    {
        currentGun = 1;
        PlayerPrefs.SetInt("CurrentGun", currentGun);
        PlayerPrefs.Save();
        buttonPistole.color = Color.green;
        buttonGewehr.color = Color.white;
        buttonSound.Play();
    }

    public void SetGewehr()
    {
        gekauft = PlayerPrefs.GetInt("Gekauft", 0);
        if(gekauft == 1)
        {
            currentGun = 2;
            PlayerPrefs.SetInt("CurrentGun", currentGun);
            PlayerPrefs.Save();
            buttonPistole.color = Color.white;
            buttonGewehr.color = Color.green;
            buttonSound.Play();
        }
        else
        {
            money = PlayerPrefs.GetInt("Money", 0);
            if(money >= 2000)
            {
                schloss.SetActive(false);
                money = money - 2000;
                PlayerPrefs.SetInt("Money", money);
                PlayerPrefs.Save();
                currentGun = 2;
                PlayerPrefs.SetInt("CurrentGun", currentGun);
                PlayerPrefs.Save();
                buttonPistole.color = Color.white;
                buttonGewehr.color = Color.green;
                gekauft = 1;
                PlayerPrefs.SetInt("Gekauft", gekauft);
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
