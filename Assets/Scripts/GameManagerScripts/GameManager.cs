using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] Slider timerSlider;
    public float timer = 300f; //In seconds
    public bool bossSpawned{get;set;}
    void Start()
    {
        timerSlider.maxValue = timer;
        bossSpawned = false;
    }
    void Update()
    {
        if (!bossSpawned)
        {
            timer = timer - Time.deltaTime;
            timerSlider.value = timer;
            if (timer <= 0f)
            {
                SpawnBoss();
            }
        }
    }

    void SpawnBoss(){
        Debug.Log("Boss Spawn");
        bossSpawned = true;
    }
}
