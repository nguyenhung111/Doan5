using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;

    public Animator anim;
    public float walkSpeed = 200f, range, timeBTWShots, shootSpeed;
    private float distance;

    [HideInInspector]
    public bool patrol;
    private bool mustTurn, canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player, shootPos;
    public GameObject bullet;
    public SoundsManager soundsManager;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        patrol = true;
        canShoot = true;
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();
    }

    void Update()
    {
        anim.SetBool("move", patrol);
        if (patrol)
        {
            Patrol(); 
        }

        distance = Vector2.Distance(transform.position, player.position);

        if (distance <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            patrol = false;
            rb.velocity = Vector2.zero;

            if (canShoot)
                StartCoroutine(Shoot());
        }
        else
        {
            patrol = true;
        }
    }
    private void FixedUpdate()
    {
        if (patrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        //di chuyển bên phải
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    // lật nhan vat
    void Flip()
    {
        patrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        patrol = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        soundsManager.Playsound("gunakm");
        canShoot = true;

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
        soundsManager.Playsound("die");
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
