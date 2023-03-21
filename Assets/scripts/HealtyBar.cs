using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtyBar : MonoBehaviour
{
    
    
    public Slider slider;

    public void SetMaxHealth(float currentHealth)
    {
        slider.maxValue = currentHealth;
        slider.value = currentHealth;
    }
    
    
    public void SetHealth(float currentHealth)
    {
        slider.value = currentHealth;
    }
}
