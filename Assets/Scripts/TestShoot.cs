using UnityEngine;
using UnityEngine.XR;

public class TestShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 2f;

    private bool triggerPressed = false;
    private float timer = 0f;

    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue && !triggerPressed)
        {
            triggerPressed = true;
            ShootBullet();
        }
        else if (!triggerValue)
        {
            triggerPressed = false;
        }
    }

    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawn.forward * bulletSpeed;
        Destroy(bullet, bulletLifetime);
    }
}
