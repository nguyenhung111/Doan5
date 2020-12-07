using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{

    public MovingFlat move;
    public Player player;

    public Vector3 moveplat;

    // Start is called before the first frame update
    void Start()
    {
        move = GameObject.FindGameObjectWithTag("Movingplat").GetComponent<MovingFlat>(); 
        player = gameObject.GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == false)
        player.grounded = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = true;

        if (collision.isTrigger == false && collision.CompareTag("Movingplat"))
        {
            moveplat = player.transform.position;
            moveplat.x += move.speed;
            player.transform.position = moveplat;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
            player.grounded = false;
    }
}