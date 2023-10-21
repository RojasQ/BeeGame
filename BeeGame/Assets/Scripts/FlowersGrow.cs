using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersGrow : MonoBehaviour
{
    public GameObject flowerPrefab;
    public Transform flowerZonePrefab;
    public int MaxFlowers = 10;
    private int flowerCount = 0;
    private Vector3[] occupiedPositions;
    public bool CanPlant = false;
    bool couroutineStarted= false;
    private SpriteRenderer m_SpriteRenderer;
    public UnlockZone UnlockObject;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        occupiedPositions = new Vector3[MaxFlowers];
    }

    private void Update() {
        
        if(CanPlant && !couroutineStarted){
            StartCoroutine(PlantFlowers());
        }

    }

    void OnMouseDown()
    {
        if(UnlockObject.UnlocksAvailable >=1 && flowerCount == 0){
                CanPlant = true;
                UnlockObject.UnlocksAvailable-= 1;
                m_SpriteRenderer.color = Color.blue;
            }
    }

    IEnumerator PlantFlowers()
    {
        couroutineStarted = true;
        yield return new WaitForSeconds(1f);
        PlantFlower();
        couroutineStarted = false;
        
    }

    void PlantFlower()
    {
        Vector3 randomPosition = GetRandomPositionInZone();

        // Verificar si la posición está ocupada
        while (IsPositionOccupied(randomPosition))
        {
            randomPosition = GetRandomPositionInZone();
        }

        Instantiate(flowerPrefab, randomPosition, Quaternion.identity);
        occupiedPositions[flowerCount] = randomPosition;
        flowerCount++;

        if (flowerCount >= MaxFlowers)
        {
            CanPlant = false;
            UnlockObject.UnlocksAvailable +=1;
        }
    }

    Vector3 GetRandomPositionInZone()
    {
        float x = Random.Range(-flowerZonePrefab.localScale.x / 2f, flowerZonePrefab.localScale.x / 2f);
        float y = Random.Range(-flowerZonePrefab.localScale.y / 2f, flowerZonePrefab.localScale.y / 2f);

        return flowerZonePrefab.position + new Vector3(x, y, 0f);
    }

    bool IsPositionOccupied(Vector3 position)
    {
        for (int i = 0; i < occupiedPositions.Length; i++)
        {
            if (Vector3.Distance(position, occupiedPositions[i]) < 1f)
            {
                return true;
            }
        }
        return false;
    }

}
