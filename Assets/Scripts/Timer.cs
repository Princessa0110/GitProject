using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class Timer : MonoBehaviour
{
   public float timeLimit;
   public Text timerText;
   public TargetSpawnManager targetSpawnManager;
   private float timeRemaining;

    private void Start() 
    {
        timeRemaining = timeLimit;
    }
   private void Update() 
   {
       if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = $"{Mathf.RoundToInt(timeRemaining)}";
            }
            else
            {
                timeRemaining = 0f;
                timerText.text = "Время закончилось!";
                targetSpawnManager.StopSpawning();
            }
        
   }
}
