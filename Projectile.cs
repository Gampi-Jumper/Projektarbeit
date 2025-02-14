using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int currentGun;
    private float speed;

    public int damage;

    void Start()
    {
        currentGun = PlayerPrefs.GetInt("CurrentGun", 1);
        if(currentGun == 1)
        {
            speed = 20;
        }
        if(currentGun == 2)
        {
            speed = 40;
        }
        if(currentGun == 3)
        {
            speed = 20;
        }

        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
