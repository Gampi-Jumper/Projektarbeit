using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    Transform player;
    public float offset;
    private int health;

    public Sprite spriteLevel1;
    public Sprite spriteLevel2;
    private SpriteRenderer spriteRenderer;

    EnemyRandom enemyRandom;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;

        enemyRandom = FindObjectOfType<EnemyRandom>();
        health = enemyRandom.random;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (health == 1)
        {
            spriteRenderer.sprite = spriteLevel1;
        }
        if (health == 2)
        {
            spriteRenderer.sprite = spriteLevel2;
        }
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Granate")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScoreGranate(1);
        }

        if (other.tag == "Projectile")
        {
            TakeDamage(other.GetComponent<Projectile>().damage);
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            SceneManager.LoadScene("MenuGameOver");
        }
    }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health == 1)
        {
            spriteRenderer.sprite = spriteLevel1;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreManager.instance.AddScore(1);
        }
    }
}
