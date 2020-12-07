using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Chuyen
{
    public class BulletDich : MonoBehaviour
    {
        GameObject target;
        public float speed;
        Rigidbody2D r2;
        Transform player;
        public int damage = 10;
        public GameObject impactEffect;

        // Start is called before the first frame update
        void Start()
        {
            r2 = GetComponent<Rigidbody2D>();
            target = GameObject.FindGameObjectWithTag("Player");
            player = GameObject.FindGameObjectWithTag("Player").transform;
            Vector2 vector2 = (target.transform.position - transform.position).normalized * speed;
            r2.velocity = new Vector2(vector2.x, vector2.y);
            Destroy(gameObject, 2);

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

    }
}