﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Reloadable))]
[RequireComponent(typeof(Rigidbody2D))]
public class Fireable : MonoBehaviour
{
    
    public GameObject bulletPrefab;

    private WeaponInfo weaponInfo;
    //private List<GameObject> bullets;
    private float timeTilFire;
    public bool canFire;
    private Transform fireLoc;
  
    private void Start()
    {
        fireLoc = GetFireLoc();
        canFire = true;
        weaponInfo = GetComponent<WeaponInfo>();
        timeTilFire = 0;
    }

    private void Update()
    {
        if(timeTilFire > 0)
            timeTilFire -= Time.deltaTime;

        // Debug.Log("Frame remain till fire: " + timeTilFire);
    }

    public void Fire(Vector2 dir)
    {
        if (CanFire())
        {
            Quaternion rot = transform.rotation;
            for (int i = 0; i < weaponInfo.bulletsPerShot; i++)
            {
                //Quaternion rotation is applied by multiplication
                GameObject projectile = Instantiate(bulletPrefab, fireLoc.position, rot * bulletPrefab.transform.rotation);
                CheckAndApplyTemporary(projectile);
                CheckAndApplyProjectileInfo(projectile);
                //Each bullet has an angle spread that deviates its angle from the aim direction
                //Each bullet also has a magnitude spread that takes the given direction and multiplies its magnitude by a random number centered around 1
                float angleSpread = CustomUtils.NextGaussian(0, weaponInfo.bulletSpreadStd, -weaponInfo.maxSpreadAng, weaponInfo.maxSpreadAng);
                float spreadMod = CustomUtils.NextGaussian(1, weaponInfo.bulletMagStd, -weaponInfo.maxSpreadMag, weaponInfo.maxSpreadMag);
                //Returns a vector that is the initial direction, rotated by angleSpread and scaled by bullet speed
                Vector2 randomizedDir = Quaternion.Euler(0, 0, angleSpread) * dir.normalized * weaponInfo.bulletSpeed;
                randomizedDir *= spreadMod;
                projectile.GetComponent<Rigidbody2D>().velocity = randomizedDir;

                //Alternate option is to add force
            }

            // temp
            GetComponent<AudioSource>().Play();
            CheckAndApplyRecoil(-1 * dir);
            // Fired - now reset time till fire with fire rate and update ammo count
            timeTilFire = weaponInfo.fireRate;
            weaponInfo.ammoLeft -= 1;
        }
    }

    bool CanFire() {
        return !(timeTilFire > 0 || !canFire || weaponInfo.ammoLeft <= 0);
    }

    Transform GetFireLoc()
    {
        foreach (Transform child in transform) {
            if (child.tag == "GunBarrel") {
                return child;
            }
        }

        return transform;
    }

    private void CheckAndApplyTemporary(GameObject obj)
    {
        Temporary temp = obj.GetComponent<Temporary>();
        if (temp != null)
            temp.startPos = transform.position;
    }

    private void  CheckAndApplyProjectileInfo(GameObject obj)
    {
        ProjectileInfo projInfo = obj.GetComponent<ProjectileInfo>();
        if (projInfo != null)
        {
            projInfo.projectileFalloff = weaponInfo.projectileFalloff * weaponInfo.projectileFalloffModifier;
            projInfo.projectileKnockback = weaponInfo.projectileKnockback * weaponInfo.projectileKnockbackModifier;
            projInfo.initialDmg = weaponInfo.baseDmg * weaponInfo.dmgModifier;
        }
    }

    private void CheckAndApplyRecoil(Vector2 dir)
    {
        Transform parent = transform.parent;
        Rigidbody2D rb2d = parent.GetComponent<Rigidbody2D>();
        if (parent != null && rb2d != null) {
            rb2d.AddForce(dir.normalized * weaponInfo.playerKnockback * weaponInfo.playerKnockbackModifier, ForceMode2D.Impulse);
        }
    }
}
