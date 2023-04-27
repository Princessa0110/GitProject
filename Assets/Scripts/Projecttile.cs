using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projecttile : MonoBehaviour
{
    protected Shooting weapon;

    public virtual void Init(Shooting weapon)
    {
        this.weapon = weapon;
    }

    public virtual void Launch()
    { 
        
    }
}
