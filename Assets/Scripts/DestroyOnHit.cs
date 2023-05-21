using System.Collections;
using System .Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    public AudioClip hitSound;
    private AudioSource audioSource;
    private TargetSpawnManager targetSpawnManager;

    private void Start() 
    {
        targetSpawnManager = FindObjectOfType<TargetSpawnManager>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(hitSound);
            Debug.Log("2");
            
            // Удаляем мишень и увеличиваем счетчик очков
            Destroy(gameObject);
            targetSpawnManager.TargetDestroyed();
            targetSpawnManager.IncreaseScore();
        }
    }
}
