using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 100f;
    public float moveSpeed = 1f;
    public float attackDamage = 10f;

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
        GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");
        GameObject[] hives = GameObject.FindGameObjectsWithTag("Hive");

        float nearestDistance = Mathf.Infinity;

        foreach (GameObject flower in flowers)
        {
            float distance = Vector3.Distance(transform.position, flower.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                targetObject = flower.transform;
            }
        }

        foreach (GameObject hive in hives)
        {
            float distance = Vector3.Distance(transform.position, hive.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                targetObject = hive.transform;
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

    void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Flower") || other.CompareTag("Hive")) && !isAttacking)
        {
            StartCoroutine(AttackTarget(other.gameObject));
        }
    }

    IEnumerator AttackTarget(GameObject target)
    {
        isAttacking = true;

        while (target != null && health > 0)
        {
            if (target.CompareTag("Flower"))
            {
                // Inflicte daño a la flor
                target.GetComponent<FloatingHp>().changeHp(attackDamage);
            }
            else if (target.CompareTag("Hive"))
            {
                // Inflicte daño a la colmena
                target.GetComponent<FloatingHp>().changeHp(attackDamage);
            }

            // Espera un tiempo antes de realizar otro ataque
            yield return new WaitForSeconds(1f);
        }

        isAttacking = false;
        FindNearestTarget(); // Busca un nuevo objetivo después de destruir el anterior
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
