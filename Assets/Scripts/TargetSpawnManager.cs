using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class TargetSpawnManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject MoveTargetPrefab;
    [HideInInspector] public float spawnRate;
    [HideInInspector] public int maxTargets;
    public Transform[] spawnPositions;

    private int targetsSpawned = 0;
    private float spawnTimer = 0f; 
    private bool spawningEnabled = true;
    private int lastSpawnedPositionIndex = -1;

    public TextMeshProUGUI textScore;

    public float Score;

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
        if(Random.value < 0.5f)
        {
            GameObject target = Instantiate(targetPrefab, spawnPositions[randomIndex].position, spawnRotation);
        }
        else
        {
            //создать движущийся объект
            GameObject target = Instantiate(MoveTargetPrefab, spawnPositions[randomIndex].position, spawnRotation);
        }
        targetsSpawned++;
    }

    public void TargetDestroyed()
    {
        targetsSpawned--;
    }

    public void StopSpawning()
    {
        spawningEnabled = false;

        // Добавьте здесь логику для уничтожения объектов или остановки их генерации.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }
    }
    public void IncreaseScore()
    {
        Score += 10;
        textScore.text = $"Score: {Score}" ;


        Debug.Log(Score);
    }
    public void Restart()
    {
      
        targetsSpawned = 0;
        spawningEnabled = true;
        Score = 0;
        textScore.text = $"Score: {Score}";

        Debug.Log(Score);

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject target in targets)
        {
            Destroy(target);
        }

    }
}
