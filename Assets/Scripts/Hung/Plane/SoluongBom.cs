using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoluongBom : MonoBehaviour
{
    public static int Soluong = 30;
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
            count.text = "Bạn đã hết bom ";
        }
       
    }
}
