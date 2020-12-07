using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    float moveSpeed = 50f;
    Rigidbody2D rb;
    public int damage = 10;
    GameObject target;
    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //xác định người chơi
        target = GameObject.FindGameObjectWithTag("Player");
        //tính toán hướng ng chơi di chuyển
        move = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(move.x, move.y);
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Flymovement enemy = collision.GetComponent<Flymovement>();
        if (enemy != null)
        {
            enemy.TakeDamege(damage);
            Destroy(gameObject);
        }
        if (collision.CompareTag("turn"))
        {
            Destroy(gameObject);
        }
    }

}
