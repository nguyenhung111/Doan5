using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 30;
    public float lifetime = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        AiEnemy Aienemy = collider.GetComponent<AiEnemy>();
        TurretAi turretAi = collider.GetComponent<TurretAi>();
        EnemyMove enemyMove = collider.GetComponent<EnemyMove>();
        Boss boss = collider.GetComponent<Boss>();
        if (Aienemy != null)
        {
            Aienemy.TakeDamage(damage);
          
        }

        if(enemyMove != null)
        {
            enemyMove.TakeDamage(damage);
        }
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }

        else if(turretAi != null)
        {
            turretAi.TakeDamage(damage);
        }
        Destroy(gameObject);

    }
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
