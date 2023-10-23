using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerScript : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    private List<GameObject> hitList = new List<GameObject>();

    void Start()
    {
        health = maxHealth;
    }

    private void takeDamage(float amountDmg){
        health -= amountDmg;
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
            hitList.Add(gameObject);
            FixedUpdate();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            hitList.Remove(gameObject);
        }
    }
    
}
