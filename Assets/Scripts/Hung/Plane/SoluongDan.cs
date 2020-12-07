using System;
using UnityEngine;
using UnityEngine.UI;

public class SoluongDan : MonoBehaviour
{

    public static int Soluong = 120;
    Text count;
    // Start is called before the first frame update
    void Start()
    {
        count = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        count.text = Convert.ToString(Soluong);
        if(Soluong == 0)
        {
            count.text = "Bạn đã hết đạn";
        }
    }
}
