using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Shooting : MonoBehaviour
{
    public int maxammo;
    private int currentammo;

    public AudioClip reloadSound;
    public AudioClip shootSound;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public float bulletLifetime = 2f;

    private bool triggerPressed = false;
    private float timer = 0f;
    private float reloadTime = 5f;

    private bool _isReloading = false;

    private AudioSource audioSource;  
    public Text ammoText;
    void Start()
{
    audioSource = GetComponent<AudioSource>();
    audioSource.playOnAwake = false;

    currentammo = maxammo;
}

    void Update()
    {
        if (_isReloading)
        {
            timer += Time.deltaTime;

            if (!(timer >= reloadTime))
            {
                return;
            }
   
                
            currentammo = maxammo;
            _isReloading = false;

            timer = 0;

            return;
        }

        var device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue) && triggerValue && !triggerPressed)
        {
            triggerPressed = true;

            if (currentammo <= 0 && !_isReloading)
            {
                Reload();
            }
            
            ShootBullet();
        }
        else if (!triggerValue)
        {
            triggerPressed = false;
        }
    }

    private void Reload()
    {
        _isReloading = true;
        audioSource.PlayOneShot(reloadSound);
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
        currentammo--;
        audioSource.PlayOneShot(shootSound);
    }

    
}
