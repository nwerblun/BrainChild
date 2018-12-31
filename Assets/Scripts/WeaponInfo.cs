using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public float baseDmg;
    public float dmgModifier;

    public float fireRate;                           // In terms of time till new shot can be fired
    public float fireRateModifier;

    public float reloadSpeed;                      // In terms of how long the reload animations takes
    public float reloadSpeedModifier;

    public int bulletsPerShot;
    public float bulletPerShotModifier;

    public float bulletSpreadMag;                     //The std of a normal distribution ceneterd around the aim direction for affecting magnitude
    public float bulletSpreadAng;                     //The std of a normal distribution ceneterd around the aim direction for affecting angle of shot
    public float maxSpreadAng;
    public float maxSpreadMag;

    public float bulletSpeed;
    public float bulletSpeedModifier;

    public int clipSize;
    public float clipSizeModifier;

    public int ammoLeft;

    // I want to add item cost in terms of $$$. Doesnt seem like it belongs here. Maybe we still have an item class?

    private void Start()
    {
        fireRate = 1 / fireRate;
    }

}
