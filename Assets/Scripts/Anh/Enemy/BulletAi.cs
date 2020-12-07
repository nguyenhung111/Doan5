using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAi : MonoBehaviour
{
    public float lifetime = 1;
    public int damage = 20;
    // public GameObject impactEffect;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (player != null)
        {
            player.PlayerDamage(damage);

        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}