using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed = 50f, maxspeed = 3, jumpPow = 300f;
    public bool grounded = true, faceright = true, doubleJump = false;

    public Rigidbody2D rb;
    public Animator anim;

    public int currenhealth;
    public int maxhealth = 100;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currenhealth = maxhealth;
        healthBar.setMaxHealth(maxhealth);
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded);//gán giá trị
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                doubleJump = true;
                rb.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(Vector2.up * jumpPow * 1f);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");//tạo biến
        rb.AddForce((Vector2.right) * speed * h);// player di chuyển

        //giới hạn tốc độ khi player đi về tay phải
        if (rb.velocity.x > maxspeed) 
            rb.velocity = new Vector2(maxspeed, rb.velocity.y);

        //giới hạn tốc độ khi player đi về tay trái
        if (rb.velocity.x < -maxspeed)
            rb.velocity = new Vector2(-maxspeed, rb.velocity.y);

        if (h > 0 && !faceright)
        {
            Flip();
        }

        if (h < 0 && faceright)
        {
            Flip();
        }

        //tạo ma sát giữa player và mặt đất
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.7f, rb.velocity.y);
        }
        if (currenhealth <= 0)
        {
            Die();
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        transform.Rotate(0f, 180f, 0);
    }

    public void Die()
    {
        //load lại scene hiện tại và build scene đó
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDamage(int damage)
    {
        currenhealth -= damage;
        gameObject.GetComponent<Animation>().Play("Redflash");
        healthBar.setHealth(currenhealth);
    }
    public void PlayerAddHealth(int health)
    {
        currenhealth += health;
        healthBar.setHealth(currenhealth);
    }
}
