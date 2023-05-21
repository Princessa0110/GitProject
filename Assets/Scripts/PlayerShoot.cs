using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Shooting _currentWeapon;
    
    private bool _triggerPressed;

    private InputDevice _rightHand;
    
    private void Update()
    {
        _rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (_rightHand.TryGetFeatureValue(CommonUsages.triggerButton, out var triggerValue) && triggerValue && !_triggerPressed)
        {
            _triggerPressed = true;

            if (_currentWeapon == null)
            {
                return;
            }

            _currentWeapon.ShootBullet();
        }
        else if (!triggerValue)
        {
            _triggerPressed = false;
        }
    }

    public void SetUpCurrentWeapon(Shooting shooting)
    {
        _currentWeapon = shooting;
    }
}
