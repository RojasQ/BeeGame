using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeScript : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float attackDamage = 50f;

    private Transform targetObject;
    private bool isAttacking = false;

    void Update()
    {
        FindNearestTarget();

        if (!isAttacking)
        {
            MoveTowardsTarget();
        }
    }

    void FindNearestTarget()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDistance = Mathf.Infinity;

        foreach (GameObject enemy in Enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                targetObject = enemy.transform;
            }
        }

    }

    void MoveTowardsTarget()
    {
        if (targetObject != null)
        {
            transform.LookAt(targetObject);
            transform.position = Vector3.MoveTowards(transform.position, targetObject.position + new Vector3(0,0,3), moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyScript>().TakeDamage(attackDamage);
            
            Destroy(this.gameObject);
        }
    }
}
