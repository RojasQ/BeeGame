using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowersGrow : MonoBehaviour
{
    public GameObject flowerPrefab;
    public GameObject ColmenaPrefab;
    public Transform flowerZonePrefab;
    public int MaxFlowers = 10;
    private int flowerCount = 0;
    private Vector3[] occupiedPositions;
    public bool CanPlant = false;
    bool couroutineStarted= false;
    private SpriteRenderer m_SpriteRenderer;
    public UnlockZone UnlockObject;
    public HoneyCount HoneyCounter;
    public GameObject ExpandAlert;

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
        Vector3 centerOfZone = GetCenterZone();

        if(UnlockObject.UnlocksAvailable >=1 && flowerCount == 0 && Time.timeScale >= 1f){
                CanPlant = true;
                UnlockObject.UnlocksAvailable-= 1;
                Instantiate(ColmenaPrefab, centerOfZone, Quaternion.identity);
                ExpandAlert.SetActive(false);
                HoneyCounter.pointsPerSecond += 1f;
            }
    }

    IEnumerator PlantFlowers()
    {
        couroutineStarted = true;
        yield return new WaitForSeconds(0.3f);
        PlantFlower();
        couroutineStarted = false;
        
    }

    void PlantFlower()
    {
        Vector3 randomPosition = GetRandomPositionInZone();

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
            ExpandAlert.SetActive(true);
        }
    }



    Vector3 GetRandomPositionInZone()
    {
        float x = Random.Range(-flowerZonePrefab.localScale.x / 2f, flowerZonePrefab.localScale.x / 2f);
        float y = Random.Range(-flowerZonePrefab.localScale.y / 2f, flowerZonePrefab.localScale.y / 2f);

        return flowerZonePrefab.position + new Vector3(x, y, 0f);
    }

    Vector3 GetCenterZone()
    {
        return flowerZonePrefab.position + new Vector3(0, 0.5f, 0f);
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
