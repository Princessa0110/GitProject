using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public int maxammo;
    private int currentammo;

    [SerializeField] private PlayerShoot _playerShoot;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    public float bulletLifetime = 2f;

    private float timer = 0f;
    private float reloadTime = 5f;

    private bool _isReloading = false;
    private bool _isReloaded;

    public Text ammoText;

    public AudioClip fire;
    public AudioClip reload;

    public AudioSource _audioSource;

    public void UpdateAmmoCurrent()
    {
        ammoText.text = currentammo.ToString();
    }

    private void Update()
    {
        if (currentammo <= 0 && !_isReloading)
        {
            Reload();
        }
        
        if (_isReloading)
        {
            timer += Time.deltaTime;

            if (!(timer >= reloadTime))
            {
                _isReloaded = true;
                return;
            }
        }

        if (!_isReloaded)
        {
            return;
        }
        
        currentammo = maxammo;
        
        _isReloading = false;
        _isReloaded = false;
        
        timer = 0;
        
        
    }
    
    private void Reload()
    {
        _isReloading = true;

        _audioSource.PlayOneShot(reload);

        UpdateAmmoCurrent();
    }
    
    public void ShootBullet()
    {
        if (_isReloading)
        {
            return;
        }
        
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
        currentammo--;
        
        _audioSource.PlayOneShot(fire);

        UpdateAmmoCurrent(); //обновляем счетчик патронов

    }
    
    public void SetUp()
    {
        _playerShoot.SetUpCurrentWeapon(this);
    }
}
