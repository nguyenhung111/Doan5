using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAll : MonoBehaviour
{
    public int health = 100;
    public GameObject death;
    public void TakeDamege(int damege)
    {
        health -= damege;
        if (health <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
