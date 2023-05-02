using UnityEngine;
using UnityEngine.XR;
using System.Collections;
using System.Collections.Generic;

public class TestShoot : MonoBehaviour
{
    public int maxammo = 10;
    private int currentammo = 10;

    public GameObject line;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 2f;

    private bool triggerPressed = false;
    private float timer = 0f;
    private float reloadTime = 5f;

    private bool _isReloading = false;
    
    

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
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
        currentammo--;
    }
}
