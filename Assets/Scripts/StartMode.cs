using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartMode : MonoBehaviour
{
    public Timer timer;
    public TargetSpawnManager targetSpawnManager;
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
            timer.Restart();
            targetSpawnManager.Restart();
        }
    }
}
