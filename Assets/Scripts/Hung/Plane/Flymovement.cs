using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Flymovement : MonoBehaviour
{
    public float Speed; // tốc độ
    public float Acceleration; //tăng tốc độ quay
    Rigidbody2D rd;
    public float RotationControl; //góc quay
  
    Vector2 movement;
    public bool grounder = true;

    public int currenhealth;
    public int maxhealth = 100;
    public Health health;

    public Transform firePoint;
    public Transform bomPoint;
    public GameObject bulletPrefab;
    public GameObject bulletBom;
    public int damage = 20;
   
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        currenhealth = maxhealth;
        health.SetMaxHealth(maxhealth);
    
      
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (SoluongDan.Soluong > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootBullet();
                SoluongDan.Soluong -= 1;
                SoundManager.shoot();
            }
        } 
        if (SoluongBom.Soluong > 0)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                ShootBom();
                SoluongBom.Soluong -= 1;
                SoundManager.Bomroi();
            }
        }
    }

    private void FixedUpdate()
    {
        //xét tốc độ quay
        Vector2 vel = transform.right * (movement.x * Acceleration);
        rd.AddForce(vel);

        float Dir = Vector2.Dot(rd.velocity, rd.GetRelativeVector(Vector2.right));
        if (Acceleration > 0)
        {
            if(Dir > 0)
            {
                rd.rotation += movement.y * RotationControl * (rd.velocity.magnitude / Speed);
            }
            else
            {
                rd.rotation -= movement.y * RotationControl * (rd.velocity.magnitude / Speed);
            }
        }

        float thrustForce  = Vector2.Dot(rd.velocity, rd.GetRelativeVector(Vector2.down))* 2.0f; // chỉnh xuống
        Vector2 relForce = Vector2.up * thrustForce;

        rd.AddForce(rd.GetRelativeVector(relForce));

        if(rd.velocity.magnitude > Speed)
        {
            rd.velocity = rd.velocity.normalized * Speed;
        }
        if (currenhealth <= 0)
        {
            Die();       
        }
    }
    public void Die()
    {
        //load lại scene hiện tại và build scene đó
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoluongBom.Soluong = 30;
        SoluongDan.Soluong = 120;
    }
    public void PlayerDamage(int damage)
    {
        currenhealth -= damage;
        health.SetHealth(currenhealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Instantiate(gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Die();

        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            Die();
        }
    }
    public void TakeDamege(int damege)
    {
        currenhealth -= damege;
        health.SetHealth(currenhealth);
        if (currenhealth <= 0)
        {
            Die();
        }
    }
    void ShootBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
    void ShootBom()
    {
        Instantiate(bulletBom, bomPoint.position, bomPoint.rotation);
    }
   
   
}
