using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class TargetSpawnManager1 : MonoBehaviour
{
    public GameObject targetPrefab1;
    public GameObject MoveTargetPrefab1;
    public float spawnRate1;
    public int maxTargets1;
    public Transform[] spawnPositions1;

    private int targetsSpawned1 = 0;
    private float spawnTimer1 = 0f;
    private bool spawningEnabled1 = true;
    private int lastSpawnedPositionIndex1 = -1;

    public TextMeshProUGUI textScore;

    public float Score1;

    private void Update()
    {
        if (spawningEnabled1 && targetsSpawned1 < maxTargets1)
        {
            spawnTimer1 += Time.deltaTime;

            if (spawnTimer1 >= spawnRate1)
            {
                SpawnTarget();
                spawnTimer1 = 0f;
            }
        }
    }

    public void SpawnTarget()
    {
        int randomIndex = Random.Range(0, spawnPositions1.Length);

        //проверяем, чтобы новая позиция не была такой же, как предыдущая
        while (randomIndex == lastSpawnedPositionIndex1)
        {
            randomIndex = Random.Range(0, spawnPositions1.Length);
        }
        lastSpawnedPositionIndex1 = randomIndex;

        Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);
        if (Random.value < 0.5f)
        {
            GameObject target = Instantiate(targetPrefab1, spawnPositions1[randomIndex].position, spawnRotation);
        }
        else
        {
            //создать движущийся объект
            GameObject target = Instantiate(MoveTargetPrefab1, spawnPositions1[randomIndex].position, spawnRotation);
        }
        targetsSpawned1++;
    }

    public void TargetDestroyed()
    {
        targetsSpawned1--;
    }

    public void StopSpawning()
    {
        spawningEnabled1 = false;

        // Добавьте здесь логику для уничтожения объектов или остановки их генерации.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }
    }
    public void IncreaseScore()
    {
        Score1 += 10;
        textScore.text = $"Score: {Score1}";


        Debug.Log(Score1);
    }
    public void Restart1()
    {

        targetsSpawned1 = 0;
        spawningEnabled1 = true;
        Score1 = 0;
        textScore.text = $"Score: {Score1}";

        Debug.Log(Score1);

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject target in targets)
        {
            Destroy(target);
        }

    }
}
