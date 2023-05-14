using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TargetSpawnManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnRate;
    public int maxTargets;
    public Transform[] spawnPositions;

    private int targetsSpawned = 0;
    private float spawnTimer = 0f;
    private bool spawningEnabled = true;
    private int lastSpawnedPositionIndex = -1;

    public Text textScore;
    private int Score = 0;

    private void Start() 
    {
        spawnTimer = spawnRate; //убрана задержка у первой мишени 
    }
    private void Update()
    {
        if (spawningEnabled && targetsSpawned < maxTargets)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnRate)
            {
                SpawnTarget();
                spawnTimer = 0f;
            }
        }
    }

    public void SpawnTarget()
    {
        int randomIndex = Random.Range(0, spawnPositions.Length);

        //проверяем, чтобы новая позиция не была такой же, как предыдущая
        while (randomIndex == lastSpawnedPositionIndex)
        {
            randomIndex = Random.Range(0, spawnPositions.Length);
        }
        lastSpawnedPositionIndex = randomIndex;

        Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);
        GameObject target = Instantiate(targetPrefab, spawnPositions[randomIndex].position, spawnRotation);

        targetsSpawned++;
    }

    public void TargetDestroyed()
    {
        targetsSpawned--;
    }

    public void StopSpawning()
    {
        spawningEnabled = false;
    }

    public void IncreaseScore()
    {
        Score += 10;
        textScore.text = $"Score: {Score}" ;
    }
}
