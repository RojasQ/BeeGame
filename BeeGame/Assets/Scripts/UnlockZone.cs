using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockZone : MonoBehaviour
{
    public int UnlocksAvailable = 0;
    public GameObject DefendersUI;

    private void Update() {

        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 0f;
            DefendersUI.SetActive(true);
        }
    }

    public void ContinueGame(){
        Time.timeScale = 1f;
    }

}
