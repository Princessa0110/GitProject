using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using TMPro;

public class Timer1 : MonoBehaviour
{
    public float timeLimit1;
    public TextMeshProUGUI timerText1;
    public TargetSpawnManager1 targetSpawnManager;
    public float timeRemaining1;
    public bool _isTimeUp1;

    private void Start()
    {
        timeRemaining1 = timeLimit1;
    }

    private void Update()
    {
        if (timeRemaining1 > 0f)
        {
            timeRemaining1 -= Time.deltaTime;
            timerText1.text = $"Time: {Mathf.RoundToInt(timeRemaining1)}";
        }
        else if (!_isTimeUp1)
        {
            _isTimeUp1 = true;
            timerText1.text = "Время закончилось!";
            targetSpawnManager.StopSpawning();
            StartCoroutine(ClearTimeUpText());
            StartCoroutine(ClearScoreUpText());
        }
    }
    private IEnumerator ClearTimeUpText()
    {
        yield return new WaitForSeconds(3f);
        timerText1.text = "";
    }

    private IEnumerator ClearScoreUpText()
    {
        yield return new WaitForSeconds(5f);
        targetSpawnManager.textScore.text = "";
    }
    public void Restart1()
    {
        timeRemaining1 = timeLimit1;
        _isTimeUp1 = false;
        timerText1.text = $"{Mathf.RoundToInt(timeRemaining1)}";
    }
}
