using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    float SpeedBullet = 8f;
    Rigidbody2D rb;
    public int damage = 30;
    GameObject target;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //xác định người chơi
        target = GameObject.FindGameObjectWithTag("Player");
        //tính toán hướng ng chơi di chuyển
        move = (target.transform.position - transform.position).normalized * SpeedBullet;
        rb.velocity = new Vector2(move.x, move.y);
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player= collision.GetComponent<Player>();
        if (player != null)
        {
            player.PlayerDamage(damage);
            Destroy(gameObject);
        }
    }
}
