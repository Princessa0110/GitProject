using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(MeshRenderer))] 
public class MeshHidder : MonoBehaviour
{
    private MeshRenderer[] meshes;
    private void Awake()
    {
        meshes= GetComponentsInChildren<MeshRenderer>();
    }
    public void Show()
    {
        foreach (var mesh in meshes)
        {
            mesh.enabled = true;
        }
    }
    public void Hide()
    {
        foreach (var mesh in meshes)
        {
            mesh.enabled = false;
        }
    }
}
