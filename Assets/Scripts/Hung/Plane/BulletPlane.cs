using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlane : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 50f;
    public int damege = 20;
    public float timeDestroy;
    public GameObject no;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
        Destroy(gameObject, timeDestroy);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyPlane enemy = hitInfo.GetComponent<EnemyPlane>();
        if(enemy != null)
        {
            enemy.TakeDamege(damege);
            Destroy(gameObject);
        }
        EnemyAll all = hitInfo.GetComponent<EnemyAll>();
        if (all != null)
        {
            all.TakeDamege(damege);
            Destroy(gameObject);
        }
        BossPlane boss = hitInfo.GetComponent<BossPlane>();
        if (boss != null)
        {
            boss.TakeDamege(damege);
            Destroy(gameObject);
        }
        if (hitInfo.gameObject.CompareTag("Ground"))
        {
            Instantiate(no, transform.position, Quaternion.identity);
            SoundManager.Explison();
            Destroy(gameObject);
        }

    }


}
