using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StartBatn1 : MonoBehaviour
{
    public Timer1 timer;
    public TargetSpawnManager1 targetSpawnManager;
    public Button startButton;

    public void Start()
    {
        startButton.onClick.AddListener(StartGame);

        timer.enabled = false;
        targetSpawnManager.enabled = false;
    }
    public void StartGame()
    {
        // Проверяем, включены ли уже компоненты timer и targetSpawnManager
        if (!timer.enabled && !targetSpawnManager.enabled)
        {
            timer.enabled = true;
            targetSpawnManager.enabled = true;
        }
        else
        {
            timer.Restart1();
            targetSpawnManager.Restart1();
        }
    }
}
