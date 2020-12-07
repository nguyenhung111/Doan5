using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlat : MonoBehaviour
{
    public float speed = 0.01f, changeDirection = -1;
    Vector3 Move;

    public PauseMenu paused;

    // Start is called before the first frame update
    void Start()
    {
        Move = this.transform.position;

        paused = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInParent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused.pause)
        {
            this.transform.position = this.transform.position;
        }
        else if( paused.pause == false)
        {
            Move.x += speed;
            this.transform.position = Move;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
}
