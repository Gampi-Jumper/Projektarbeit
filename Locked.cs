using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{
    public int abLevel;
    private int level;

    void Start()
    {
        level = PlayerPrefs.GetInt("Level", 1);
        if (level >= abLevel)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
