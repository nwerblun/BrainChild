using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public float baseDmg;
    public float dmgModifier = 1;
    public float fireRate;                           // In terms of time till new shot can be fired
    public float fireRateModifier = 1;
    public float reloadSpeed;                      // In terms of how long the reload animations takes
    public float reloadSpeedModifier = 1;
    public int bulletsPerShot;
    public float bulletPerShotModifier = 1;
    public float bulletMagStd;                     //The std of a normal distribution ceneterd around the aim direction for affecting magnitude
    public float bulletSpreadStd;                     //The std of a normal distribution ceneterd around the aim direction for affecting angle of shot
    public float maxSpreadAng;
    public float maxSpreadMag;
    public float bulletSpeed;
    public float bulletSpeedModifier = 1;
    public int clipSize;
    public float clipSizeModifier = 1;
    public int ammoLeft;
    public float playerKnockback;
    public float playerKnockbackModifier = 1;
    public float projectileKnockback;
    public float projectileKnockbackModifier = 1;
    public float projectileFalloff;
    public float projectileFalloffModifier = 1;

    // I want to add item cost in terms of $$$. Doesnt seem like it belongs here. Maybe we still have an item class?

    private void Start()
    {

    }

}
