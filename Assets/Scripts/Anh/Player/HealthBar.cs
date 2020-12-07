using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void  setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        //xét màu full image lúc máu tối đa
        fill.color = gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        slider.value = health;

        //xét màu image theo lượng máu của player
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
