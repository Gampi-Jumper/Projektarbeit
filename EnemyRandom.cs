using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : MonoBehaviour
{
    public float acceleration;
    private float currentProbability = 0f;

    public int random;

    void Update()
    {
        currentProbability += acceleration * Time.deltaTime;
        currentProbability = Mathf.Clamp01(currentProbability);
        
        if (Random.value < currentProbability)
        {
            random = 2;
        }
        else
        {
            random = 1;
        }
    }

}
