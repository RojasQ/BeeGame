using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform spawnPoint; // Punto de generación de enemigos
    public int numberOfEnemies = 2; // Número de enemigos a generar
    private float cdSpawn = 10f;

    private void Update() {

        cdSpawn -= Time.deltaTime;

        if(cdSpawn<=0){
            GenerateEnemies();
            cdSpawn = 10f;
        }
    }

    void GenerateEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Genera el enemigo en la posición del spawnPoint con una pequeña variación
            Vector2 spawnPosition = spawnPoint.position + Random.insideUnitSphere * 2f;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
