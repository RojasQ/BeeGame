using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAndLose : MonoBehaviour
{
    public GameObject Win;
    public GameObject Lose;
    private float TimeToWin;

    private void OnDestroy() {

        Lose.SetActive(true);
        
    }

    private void Update() {

        TimeToWin += Time.deltaTime;

        if(TimeToWin>=120){
            Win.SetActive(true);
        }
    }
}
