using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCreation : MonoBehaviour
{
    public GameObject beePrefab;
    public void CreateNewBee(){
        Vector3 BeePosition = new Vector3(Random.Range(-2,2), Random.Range(-2,2), 0f);
        Instantiate(beePrefab, BeePosition, Quaternion.identity);
    }
}
