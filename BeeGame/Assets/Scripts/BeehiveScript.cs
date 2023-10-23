using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeehiveScript : MonoBehaviour
{

    public float health;
    public float maxHealth;
    private List<GameObject> hitList = new List<GameObject>();
    [SerializeField] FloatingHp healthBar;
    void Start()
    {
        health = maxHealth;
        healthBar.changeHp(maxHealth, health);
    }

    private void takeDamage(float amountDmg){
        health -= amountDmg;
        healthBar.changeHp(maxHealth, health);
        Debug.Log(health);
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    
    private void FixedUpdate() {
        if (hitList.Count != 0)
        {
            takeDamage(2f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            Debug.Log(gameObject);
            hitList.Add(gameObject);
            FixedUpdate();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            Debug.Log(gameObject);
            hitList.Remove(gameObject);
        }
    }

    void Update()
    {
        
    }
}
