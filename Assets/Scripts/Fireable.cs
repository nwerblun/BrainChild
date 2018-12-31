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
            Debug.Log("Shots fired: " + weaponInfo.bulletsPerShot);

            // temp
            Vector2 initialDir = Vector2.right;
            for (int i = 0; i < weaponInfo.bulletsPerShot; i++)
            {
                GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                // temp spread calculations
                float angleSpread = CustomUtils.NextGaussian(0, weaponInfo.bulletSpreadAng, -weaponInfo.maxSpreadAng, weaponInfo.maxSpreadAng);
                float spreadModX = CustomUtils.NextGaussian(0, weaponInfo.bulletSpreadMag, -weaponInfo.maxSpreadMag, weaponInfo.maxSpreadMag);
                float spreadModY = CustomUtils.NextGaussian(0, weaponInfo.bulletSpreadMag, weaponInfo.maxSpreadMag, weaponInfo.maxSpreadMag);

                projectile.GetComponent<Rigidbody2D>().velocity = initialDir.Rotate(0, 0, angleSpread);
               // projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(initialDir.x + spreadModX, initialDir.y + spreadModY) * weaponInfo.bulletSpeed;
            }

            // temp
            GetComponent<AudioSource>().Play();

            // Fired - now reset time till fire with fire rate
            timeTilFire = weaponInfo.fireRate;
 

            //Alternate option is to add force
            //projectile.GetComponent<Rigidbody2D>().AddForce(dir * someForceValue);
        }
    }

    public void SetFiringActive(bool enable) {
        canFire = enable;
        return;
    }

    public bool CanFire() {
     
        if (timeTilFire > 0 || !canFire || weaponInfo.ammoLeft <= 0)
            return false;
        else
            return true;
    }
}
