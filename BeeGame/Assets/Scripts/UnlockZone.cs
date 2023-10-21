using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockZone : MonoBehaviour
{
    public int UnlocksAvailable = 0;

    private void Update() {
        Debug.Log(UnlocksAvailable);

        if(UnlocksAvailable >= 1){
            
        }
    }

    public void CountUnlocks(){

        UnlocksAvailable += 1;

    }
}
