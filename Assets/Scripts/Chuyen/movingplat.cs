using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplat : MonoBehaviour
{
    public float speed = 0.03f, changeDirection = -1;
    Vector3 Move;

    public PauseUI pauseUI;

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
        pauseUI = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PauseUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseUI.pause)
        {
            this.transform.position = this.transform.position;
        }
        else if(pauseUI.pause == false){ 
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
