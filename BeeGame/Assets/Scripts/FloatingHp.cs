using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update() {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
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
