using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAi : MonoBehaviour
{
    public int health = 100;
    public GameObject deathEffect;
    public float range, timeBTWShots, shootSpeed;
    private float distance;

    public Transform player, shootPos;
    public GameObject bullet;
    public SoundsManager soundsManager;

    private bool mustTurn, canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        soundsManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        if (distance <= range)
        {
            if (canShoot)
                StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * -1 * Time.fixedDeltaTime, 0f);
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
