using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log("Shots fired: " + weaponInfo.bullets_per_shot);

            // temp

            for(int i = 0; i < weaponInfo.bullets_per_shot; i++)
            {
                GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

                // temp spread calculations
                projectile.GetComponent<Rigidbody2D>().velocity = (new Vector2(1, 0 + Random.Range(-1.0f, 1.0f) * weaponInfo.bullet_spread) * weaponInfo.bullet_speed);
            }

            // temp
            GetComponent<AudioSource>().Play();

            // Fired - now reset time till fire with fire rate
            timeTilFire = weaponInfo.fire_rate;
 

            //Alternate option is to add force
            //projectile.GetComponent<Rigidbody2D>().AddForce(dir * someForceValue);
        }
    }

    public bool CanFire() {
     
        if (timeTilFire > 0)
            return false;
        else
            return true;
    }
}
