using UnityEngine;
using UnityEngine.UI;

public class StartMode2 : MonoBehaviour
{
    public TargetSpawnManager targetSpawnManager;
    public Timer timer;

    private void Start()
    {
        timer.enabled = false;
        targetSpawnManager.enabled = false; 

        GetComponent<Button>().onClick.AddListener(EnableHardMode);
    }

    public void EnableHardMode()
    {
        timer.enabled = true;
        targetSpawnManager.enabled = true; 
        // Установите параметры для режима "Ветеран"
        targetSpawnManager.spawnRate = 1.5f;
        targetSpawnManager.maxTargets = 7;
        timer.timeLimit = 30f;

        // Перезапустите игру
        targetSpawnManager.Restart();
        timer.Restart();
    }
}
