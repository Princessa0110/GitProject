using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Shooting : MonoBehaviour
{
    [SerializeField] protected float shootingForce; //���� ��������
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] protected float recoilForce; //���� ������
    [SerializeField] protected float damge; //����

    private Rigidbody rigidbody;
    private XRGrabInteractable interactableWeapon;

    protected virtual void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidbody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.onSelectEntered.AddListener(PickAppWeapon);
        interactableWeapon.onSelectEntered.AddListener(DropWeapon);
        interactableWeapon.onSelectEntered.AddListener(StartShooting);
        interactableWeapon.onSelectEntered.AddListener(StopShooting);

    }

    protected virtual void StopShooting(XRBaseInteractor interactor)
    {
        throw new NotImplementedException();
    }

    protected virtual void StartShooting(XRBaseInteractor interactor)
    {
        throw new NotImplementedException();
    }

    private void DropWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHidder>().Show();
    }

    private void PickAppWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHidder>().Hide();
    }

    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rigidbody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage()
    {
        return damge;
    }
}