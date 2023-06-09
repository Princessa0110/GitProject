using UnityEngine;
using UnityEngine.UI;

public class StartMode : MonoBehaviour
{
    public TargetSpawnManager targetSpawnManager;
    public Timer timer;

    private void Start()
    {
        timer.enabled = false;
        targetSpawnManager.enabled = false; 

        GetComponent<Button>().onClick.AddListener(EnableEasyMode);
    }

    public void EnableEasyMode()
    {
        timer.enabled = true;
        targetSpawnManager.enabled = true; 
        // Установите параметры для режима "Easy"
        targetSpawnManager.spawnRate = 3f;
        targetSpawnManager.maxTargets = 3;
        timer.timeLimit = 60f;

        // Перезапустите игру
        targetSpawnManager.Restart();
        timer.Restart();
    }
}
