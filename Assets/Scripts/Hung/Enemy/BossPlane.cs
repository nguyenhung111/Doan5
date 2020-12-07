using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlane : MonoBehaviour
{
    public float speed;
    private Transform player;
    public float shootingRange;
    public float fireRate = 5f;
    private float nextFireTime;
    public float fireRateBom = 10f;
    private float nextFireTimeBom;
    public GameObject bullet,bulletBom;
    public GameObject bulletParent,fireBomboss;
    public int health = 500;
    public GameObject death;
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
            if (distance <= shootingRange && nextFireTime < Time.time)
            {
                Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
                nextFireTime = Time.time + fireRate;
            }
            if (distance <= shootingRange && nextFireTimeBom < Time.time)
            {
                Instantiate(bulletBom, fireBomboss.transform.position, Quaternion.identity);
                nextFireTimeBom = Time.time + fireRateBom;
            }

        }
       
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
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
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
