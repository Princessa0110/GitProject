using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class StartBatn2 : MonoBehaviour
{
    public Timer2 timer;
    public TargetSpawnManager2 targetSpawnManager;
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
            timer.Restart2();
            targetSpawnManager.Restart2();
        }
    }
}
