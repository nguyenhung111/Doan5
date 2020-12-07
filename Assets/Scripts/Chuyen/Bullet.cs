using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public int damage = 40;
    public Rigidbody2D r2;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        r2.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 2f); // Destroy Gameobject, after 2 Seconds.

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bom bom = collision.GetComponent<bom>();
        if (bom != null)
        {
            bom.TakeDamage(damage);
        }
        if (collision.CompareTag("bom"))
        {
            Destroy(gameObject);
        }

        tankdich tankdich = collision.GetComponent<tankdich>();
        if (tankdich != null)
        {
            tankdich.TakeDamage(damage);
        }
        if (collision.CompareTag("tankdich"))
        {

            Destroy(gameObject);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "")
        {
            //  Destroy(gameObject); // Just destroy Gameobject, without delay.

            Destroy(gameObject, 3f); // Destroy GameObject after 5 Seconds.
        }
    }
}
