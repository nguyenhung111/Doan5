using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timedelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        //nếu player chạm vào sẽ rơi
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }

    //tile rơi
    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;
    }
}
