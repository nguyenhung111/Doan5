using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Chuyen
{
    public class Player : MonoBehaviour
    {

        public float speed = 30f, maxspeed = 3;
        public bool grounded = true, faceright = true;

        public int maxHealth = 100;
        public int currentHealth;
        public HealthBar healthBar;

        public Rigidbody2D r2;
        public Animator anim;
        public void PlayerAddHealth(int health)
        {
            currentHealth += health;
            healthBar.SetHealth(currentHealth);
        }
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);

            r2 = gameObject.GetComponent<Rigidbody2D>();
            anim = gameObject.GetComponent<Animator>();



        }

        // Update is called once per frame
        void Update()
        {
            anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));


        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
        }




        void FixedUpdate()
        {
            float h = Input.GetAxis("Horizontal");
            r2.AddForce(Vector2.right * speed * h);
            if (r2.velocity.x > maxspeed)
                r2.velocity = new Vector2(maxspeed, r2.velocity.y);
            if (r2.velocity.x < -maxspeed)
                r2.velocity = new Vector2(-maxspeed, r2.velocity.y);
            if (grounded)
            {
                r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
            }

            if (currentHealth <= 0)
            {
                Death();
            }



        }
        public void Death()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("bom"))
            {
                TakeDamage(20);
            }
            if (collision.gameObject.CompareTag("tankdich"))
            {
                TakeDamage(20);
            }
            if (collision.gameObject.CompareTag("Mau"))
            {
                PlayerAddHealth(10);
            }

        }



    }
}