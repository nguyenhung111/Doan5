using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 200;
    public GameObject deathEffect;
    private Transform player;
    public float range;
    public float timeBullet1 = 2f;
    private float nextFireTime;
    public float timeBullet2 = 3f;
    private float nextFireTime2;
    public GameObject bullet, bullet2;
    public GameObject firebullet, firebullet2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(player.position, transform.position);
            if (distance <= range && nextFireTime < Time.time)
            {
                Instantiate(bullet, firebullet.transform.position, Quaternion.identity);
                nextFireTime = Time.time + timeBullet1;
            }
            if (distance <= range && nextFireTime2 < Time.time)
            {
                Instantiate(bullet2, firebullet2.transform.position, Quaternion.identity);
                nextFireTime2 = Time.time + timeBullet2;
            }

        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}