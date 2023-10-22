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
            float distance = Vector2.Distance(transform.position, enemy.transform.position);

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
            Vector2 targetposition = targetObject.position;

            // Obtiene la dirección hacia el objetivo
            Vector3 direction = targetObject.position - transform.position;

            // Calcula el ángulo en radianes
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Rota el objeto hacia el ángulo calculado
            transform.rotation = Quaternion.AngleAxis(angle-80, Vector3.forward);

            transform.position = Vector2.MoveTowards(transform.position, targetposition, moveSpeed * Time.deltaTime);
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
