using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkground : MonoBehaviour
{
    public Player player;
    public movingplat mov;

    public Vector3 movep;

    // Use this for initialization
    void Start()
    {
        mov = GameObject.FindGameObjectWithTag("movingplat").GetComponent<movingplat>();
        player = gameObject.GetComponentInParent<Player>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = true;
        if (collision.isTrigger == false && collision.CompareTag("movingplat"))
        {
            movep = player.transform.position;
            movep.x += mov.speed * 1.3f;
            player.transform.position = movep;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false || collision.CompareTag("water"))
            player.grounded = false;
    }
}
