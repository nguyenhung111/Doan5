using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAI : MonoBehaviour
{
    public Animator anim;
    public Player player;
    public int damagetrap = 20;

    public float distance; //khoảng cách giữa player và trap
    public float wakerange; //phạm vi thức tỉnh

    public bool awake = false;
    public Transform target; // mục tiêu

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Awake", awake);
        RangeCheck();
    }
    void RangeCheck()
    {
        // tính khoảng cách giữa trap và player
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance<= wakerange)
        {
            awake = true;
        }
        if(distance > wakerange)
        {
            awake = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.PlayerDamage(damagetrap);
        }
    }
}
