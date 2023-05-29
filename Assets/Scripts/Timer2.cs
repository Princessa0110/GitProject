using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;
using TMPro;

public class Timer2 : MonoBehaviour
{
    public float timeLimit2;
    public TextMeshProUGUI timerText2;
    public TargetSpawnManager1 targetSpawnManager;
    public float timeRemaining2;
    public bool _isTimeUp2;

    private void Start()
    {
        timeRemaining2 = timeLimit2;
    }

    private void Update()
    {
        if (timeRemaining2 > 0f)
        {
            timeRemaining2 -= Time.deltaTime;
            timerText2.text = $"Time: {Mathf.RoundToInt(timeRemaining2)}";
        }
        else if (!_isTimeUp2)
        {
            _isTimeUp2 = true;
            timerText2.text = "Время закончилось!";
            targetSpawnManager.StopSpawning();
            StartCoroutine(ClearTimeUpText());
            StartCoroutine(ClearScoreUpText());
        }
    }
    private IEnumerator ClearTimeUpText()
    {
        yield return new WaitForSeconds(3f);
        timerText2.text = "";
    }

    private IEnumerator ClearScoreUpText()
    {
        yield return new WaitForSeconds(5f);
        targetSpawnManager.textScore.text = "";
    }
    public void Restart2()
    {
        timeRemaining2 = timeLimit2;
        _isTimeUp2 = false;
        timerText2.text = $"{Mathf.RoundToInt(timeRemaining2)}";
    }
}
