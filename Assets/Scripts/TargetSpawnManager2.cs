using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class TargetSpawnManager2 : MonoBehaviour
{
    public GameObject targetPrefab2;
    public GameObject MoveTargetPrefab2;
    public float spawnRate2;
    public int maxTargets2;
    public Transform[] spawnPositions2;

    private int targetsSpawned2 = 0;
    private float spawnTimer2 = 0f;
    private bool spawningEnabled2 = true;
    private int lastSpawnedPositionIndex2 = -1;

    public TextMeshProUGUI textScore;

    public float Score2;

    private void Update()
    {
        if (spawningEnabled2 && targetsSpawned2 < maxTargets2)
        {
            spawnTimer2 += Time.deltaTime;

            if (spawnTimer2 >= spawnRate2)
            {
                SpawnTarget();
                spawnTimer2 = 0f;
            }
        }
    }

    public void SpawnTarget()
    {
        int randomIndex = Random.Range(0, spawnPositions2.Length);

        //проверяем, чтобы новая позиция не была такой же, как предыдущая
        while (randomIndex == lastSpawnedPositionIndex2)
        {
            randomIndex = Random.Range(0, spawnPositions2.Length);
        }
        lastSpawnedPositionIndex2 = randomIndex;

        Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);
        if (Random.value < 0.5f)
        {
            GameObject target = Instantiate(targetPrefab2, spawnPositions2[randomIndex].position, spawnRotation);
        }
        else
        {
            //создать движущийся объект
            GameObject target = Instantiate(MoveTargetPrefab2, spawnPositions2[randomIndex].position, spawnRotation);
        }
        targetsSpawned2++;
    }

    public void TargetDestroyed()
    {
        targetsSpawned2--;
    }

    public void StopSpawning()
    {
        spawningEnabled2 = false;

        // Добавьте здесь логику для уничтожения объектов или остановки их генерации.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }
    }
    public void IncreaseScore()
    {
        Score2 += 10;
        textScore.text = $"Score: {Score2}";


        Debug.Log(Score2);
    }
    public void Restart2()
    {

        targetsSpawned2 = 0;
        spawningEnabled2 = true;
        Score2 = 0;
        textScore.text = $"Score: {Score2}";

        Debug.Log(Score2);

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");

        foreach (GameObject target in targets)
        {
            Destroy(target);
        }

    }
}
