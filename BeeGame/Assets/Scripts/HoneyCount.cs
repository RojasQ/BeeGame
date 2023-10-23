using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HoneyCount : MonoBehaviour
{
    public float pointsPerSecond = 1f;
    public int BeeAmount = 0;
    public TMP_Text scoreText;
    public TMP_Text amountOfBees; // Asigna el objeto Text desde el Inspector
    public GameObject beePrefab;

    private float score = 0f;

    void Update()
    {
        // Suma puntos cada segundo
        score += pointsPerSecond * Time.deltaTime;

        // Actualiza el texto en el objeto UI
        UpdateScoreUI();

    }

    public void MorebeesMorePoints(){


        if(BeeAmount<20){
            if(score>=3){
                BeeAmount += 1;
                amountOfBees.text = BeeAmount.ToString() + "/20";
                pointsPerSecond+=0.1f;
                score-= 3;
            }
            
        }
    }

    public void LessBees(){

        BeeAmount -= 1;
        amountOfBees.text = BeeAmount.ToString() + "/20";
        pointsPerSecond-=0.1f;

    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            // Convierte el puntaje a entero si lo prefieres
            int scoreInt = Mathf.FloorToInt(score);
            scoreText.text = scoreInt.ToString();
        }
    }
}
