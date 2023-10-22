using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void setMaxHp(float maxHp){
        slider.maxValue = maxHp;
    }

    public void changeHp(float amount){
        slider.value = amount;
    }

    public void initializeHpBar(float initialHp){
        setMaxHp(initialHp);
        changeHp(initialHp);
    }
}
