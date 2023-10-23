using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeCreation : MonoBehaviour
{
    public GameObject beePrefab;
    public HoneyCount HoneyCounter;
    public void CreateNewBee(){

        if(HoneyCounter.BeeAmount<20){

            HoneyCounter.MorebeesMorePoints();
            Vector3 BeePosition = new Vector3(Random.Range(-2,2), Random.Range(-2,2), 0f);
            Instantiate(beePrefab, BeePosition, Quaternion.identity);
        }
    }
}
