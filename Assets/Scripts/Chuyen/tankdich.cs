using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankdich : MonoBehaviour
{
	public float speed;
	public bool MoveLeft;
	public GameObject deathEffect;
	public int health = 100;
	private Transform player;
	public float lineOfsite;
	public float shootingRange;
	public GameObject bullet;
	public GameObject bulletParent;
	public float fireRate = 1f;
	public float nextFireTime;



    // Use this for initialization
     void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
    void Update()
	{
		// Use this for initialization
		if (MoveLeft)
		{
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(-1, 1);
		}
		else
		{
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(1, 1);

		}
		if(health <= 0 )
        {
			Die();
        }
		float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
		 if(distanceFromPlayer<=shootingRange && nextFireTime < Time.time)
        {
			Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
			nextFireTime = Time.time + fireRate;
        }			
	}
	void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.CompareTag("turn"))
		{

			if (MoveLeft)
			{
				MoveLeft = false;
			}
			else
			{
				MoveLeft = true;
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
    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, lineOfsite);
		Gizmos.DrawWireSphere(transform.position, shootingRange);


	}
}
