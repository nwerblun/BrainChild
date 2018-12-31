using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Reloadable))]
public class Fireable : MonoBehaviour
{
    
    public GameObject bulletPrefab;

    private WeaponInfo weaponInfo;
    //private List<GameObject> bullets;
    private float timeTilFire;
    public bool canFire;

  

    private void Start()
    {
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

    public void Fire()
    {
        if (CanFire())
        {
            Vector2 initialDir = Vector2.right;
            for (int i = 0; i < weaponInfo.bulletsPerShot; i++)
            {
                GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Temporary temp = projectile.GetComponent<Temporary>();
                if (temp != null)
                    temp.startPos = transform.position;

                //Each bullet has an angle spread that varies its angle from the aim direction
                //Each bullet also has a magnitude spread that takes the given direction and multiplies its magnitude by a random number centered around 1
                float angleSpread = CustomUtils.NextGaussian(0, weaponInfo.bulletSpreadStd, -weaponInfo.maxSpreadAng, weaponInfo.maxSpreadAng);
                float spreadMod = CustomUtils.NextGaussian(1, weaponInfo.bulletMagStd, -weaponInfo.maxSpreadMag, weaponInfo.maxSpreadMag);
                //Returns a vector that is the initial direction, rotated by angleSpread and scaled by bullet speed
                Vector2 randomizedDir = Quaternion.Euler(0, 0, angleSpread) * initialDir * weaponInfo.bulletSpeed;
                randomizedDir.x *= spreadMod;
                randomizedDir.y *= spreadMod;
                projectile.GetComponent<Rigidbody2D>().velocity = randomizedDir;

                //Alternate option is to add force
                //projectile.GetComponent<Rigidbody2D>().AddForce(dir * someForceValue);
            }

            // temp
            GetComponent<AudioSource>().Play();

            // Fired - now reset time till fire with fire rate
            timeTilFire = weaponInfo.fireRate;
            weaponInfo.ammoLeft -= 1;
        }
    }

    public void SetFiringActive(bool enable) {
        canFire = enable;
        return;
    }

    public bool CanFire() {
        return !(timeTilFire > 0 || !canFire || weaponInfo.ammoLeft <= 0);
    }
}
