using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float speed;
    public bool MoveRight;
    public Rigidbody2D rb;
    //public GameObject bullet;
    //public float nextFire, fireRate;
    void Start()
    {
        //fireRate = 50f;
        //nextFire = Time.time;
    }
    void Update()
    {
        if (!MoveRight)
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(15, 15);
          
        }
        else
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-15, 15);
           
        }
        //if (Time.time > nextFire)
        //{
        //    Instantiate(bullet, transform.position, Quaternion.identity);
        //    nextFire = Time.time + fireRate;
        //}

    }
    public void TakeDamege(int damege)
    {
        health -= damege;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SoundManager.Explison();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("turn"))
        {
            if (MoveRight)
            {
                MoveRight = false;

            }
            else
            {
                MoveRight = true;
            }
        }
    }
}
