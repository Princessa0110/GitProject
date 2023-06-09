using System.Collections;
using System .Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    private TargetSpawnManager targetSpawnManager;

    private void Start() 
    {
        targetSpawnManager = FindObjectOfType<TargetSpawnManager>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Удаляем мишень и увеличиваем счетчик очков
            Destroy(gameObject);
            targetSpawnManager.IncreaseScore();
            targetSpawnManager.TargetDestroyed();
            targetSpawnManager.SpawnTarget();
        }
    }
}
