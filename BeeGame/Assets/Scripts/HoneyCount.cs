using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HoneyCount : MonoBehaviour
{
    public float pointsPerSecond = 1f;
    public TMP_Text scoreText; // Asigna el objeto Text desde el Inspector

    private float score = 0f;

    void Update()
    {
        // Suma puntos cada segundo
        score += pointsPerSecond * Time.deltaTime;

        // Actualiza el texto en el objeto UI
        UpdateScoreUI();
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
