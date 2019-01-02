using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    //Has info about who shot it??
    public float projectileKnockback;
    public float initialDmg;
    public float projectileFalloff;

    private void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Call the hit object's "TakesDamageFromProjectiles" hit method and update it with vals
        Destroy(gameObject);
    }
}
