using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Granate : MonoBehaviour
{
    public Animation explotionAnimation;

    public GameObject granateGameObject;

    public int currentScene;
    private int money;
    private int granates;

    public AudioSource buySound;
    public AudioSource errorSound;
    public AudioSource explosionSound;

    public TextMeshProUGUI granatesText;

    void Start()
    {
        granates = PlayerPrefs.GetInt("Granates", 0);
        granatesText.text = granates.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentScene == 1)
        {
            Explode();
        }
    }

    public void BuyGranate()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        if(money >= 100)
        {
            money = money - 100;
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.Save();
            granates = PlayerPrefs.GetInt("Granates", 0);
            granates = granates + 1;
            PlayerPrefs.SetInt("Granates", granates);
            PlayerPrefs.Save();
            granatesText.text = granates.ToString();
            buySound.Play();
        }
        else
        {
            errorSound.Play();
        }
    }

    public void Explode()
    {
        granates = PlayerPrefs.GetInt("Granates", 0);
        if(granates >= 1)
        {
            granates = granates - 1;
            PlayerPrefs.SetInt("Granates", granates);
            PlayerPrefs.Save();
            granates = PlayerPrefs.GetInt("Granates", 0);
            granatesText.text = granates.ToString();         
            StartCoroutine(Explosion());

        }
        else
        {
            errorSound.Play();
        }
    }

    private IEnumerator Explosion()
    {
        explosionSound.Play();
        explotionAnimation.Play("Explosion");
        granateGameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        granateGameObject.SetActive(false);
    }
}
