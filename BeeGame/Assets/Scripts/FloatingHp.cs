using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHp : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    public  Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Awake() {
        transform.position = target.position + offset;
    }

    private void Update() {
        transform.position = target.position + offset;
    }

    public void setMaxHp(float maxHp){
        slider.maxValue = maxHp;
    }

    public void changeHp(float maxHp, float currentHp){
        slider.value = currentHp/maxHp;
    }

}
