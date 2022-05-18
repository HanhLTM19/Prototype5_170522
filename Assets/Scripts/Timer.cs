using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer = 60;
    public TextMeshProUGUI timerText;
    GameController gameController;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
        timerText.text = "Time:" + timer.ToString("0");
    }
}
