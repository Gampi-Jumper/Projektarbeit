using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
