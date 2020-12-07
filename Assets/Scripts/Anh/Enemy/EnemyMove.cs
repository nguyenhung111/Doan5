using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect;
    public float speed = 1f;
    public bool moveright;
    public Animator anim;
    public SoundsManager soundsManager;


    private void Start()
    {
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        anim.SetFloat("Speed", speed);
        if (!moveright)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);

        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.Rotate(0f, 180f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            if (moveright)
            {
                moveright = false;

            }
            else
            {
                moveright = true;
            }
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        soundsManager.Playsound("die");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
