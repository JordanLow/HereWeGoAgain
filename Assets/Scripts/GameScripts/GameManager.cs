using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float timer = 300f; // In seconds

    public bool bossSpawned{get;set;}

    void Start()
    {
        timerText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
        bossSpawned = false;
    }

    void Update()
    {
        if (!bossSpawned)
        {
            timer = timer - Time.deltaTime;
            if (timer <= 0f)
            {
                SpawnBoss();
				timerText.text = "!!BOSS!!";
            } else {
				timerText.text = string.Format("{0:00}:{1:00}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60));
			}
        }
    }

    void SpawnBoss(){
        Debug.Log("Boss Spawn");
        bossSpawned = true;
    }
}
