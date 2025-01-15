using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite spritePistole;
    public Sprite spriteSniper;
    private int currentGun;

    public float offset;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 displacement = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + offset);

        currentGun = PlayerPrefs.GetInt("CurrentGun", 1);
        if(currentGun == 1)
        {
            spriteRenderer.sprite = spritePistole;
        }
        else
        {
            spriteRenderer.sprite = spriteSniper;
        }
    }
}
