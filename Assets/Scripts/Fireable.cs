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

        }
    }

    public bool CanFire() {
        return true;
    }
}
