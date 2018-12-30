using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Reloadable))]
public class Fireable : MonoBehaviour
{
    public GameObject bulletPrefab;
    public bool canFire;

    public void Fire() {
        if (CanFire()) {
            GameObject projectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = (new Vector2(1, 0)) * 10;
            //Alternate option is to add force
            //projectile.GetComponent<Rigidbody2D>().AddForce(dir * someForceValue);
        }
    }

    public bool CanFire() {
        return true;
    }
}
