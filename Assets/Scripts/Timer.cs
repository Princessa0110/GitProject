using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using TMPro;

public class Timer : MonoBehaviour
{
   public float timeLimit;
   public TextMeshProUGUI timerText;
   public TargetSpawnManager targetSpawnManager;
   public float timeRemaining;
   public bool _isTimeUp;

    private void Start() 
    {
        timeRemaining = timeLimit;
    }
    
   private void Update() 
   {          
        if (timeRemaining > 0f)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = $"Time: {Mathf.RoundToInt(timeRemaining)}";
        }
        else if(!_isTimeUp)
        {
            _isTimeUp = true;
            timerText.text = "Время закончилось!";
            targetSpawnManager.StopSpawning();
            StartCoroutine(ClearTimeUpText());
            StartCoroutine(ClearScoreUpText());
        }
   }
   private IEnumerator ClearTimeUpText()
   {
      yield return new WaitForSeconds(3f);
      timerText.text = "";
   }

   private IEnumerator ClearScoreUpText()
   {
        yield return new WaitForSeconds(5f);
        targetSpawnManager.textScore.text = "";
   }
   public void Restart()
    {
        timeRemaining = timeLimit;
        _isTimeUp = false;
        timerText.text = $"{Mathf.RoundToInt(timeRemaining)}";
    }
}
