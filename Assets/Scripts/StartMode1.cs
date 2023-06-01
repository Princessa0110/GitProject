using UnityEngine;
using UnityEngine.UI;

public class StartMode1 : MonoBehaviour
{
    public TargetSpawnManager targetSpawnManager;
    public Timer timer;

    private void Start()
    {
        timer.enabled = false;
        targetSpawnManager.enabled = false; 

        GetComponent<Button>().onClick.AddListener(EnableMediumMode);
    }

    public void EnableMediumMode()
    {
        timer.enabled = true;
        targetSpawnManager.enabled = true; 
        // Установите параметры для режима "Medium"
        targetSpawnManager.spawnRate = 3;
        targetSpawnManager.maxTargets = 5;
        timer.timeLimit = 45f;

        // Перезапустите игру
        targetSpawnManager.Restart();
        timer.Restart();
    }
}
