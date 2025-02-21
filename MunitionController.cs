using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionController : MonoBehaviour
{
    public GameObject infiniteGameObject;
    public GameObject munitionGameObject;

    private int currentGun;

    void Update()
    {
        if(currentGun == 3)
        {
            infiniteGameObject.SetActive(true);
            munitionGameObject.SetActive(false);
        }
        else
        {
            infiniteGameObject.SetActive(false);
            munitionGameObject.SetActive(true);
        }
    }
}
