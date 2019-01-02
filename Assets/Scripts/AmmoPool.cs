using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPool : MonoBehaviour
{
    public int shotgunAmmo;
    public int rifleAmmo;
    public int pistolAmmo;

    public int maxShotgunAmmo;
    public int maxRifleAmmo;
    public int maxPistolAmmo;

    //Add more later

    //Returns how much ammo you got
    public int TakeAmmo(int amount, CustomUtils.WeaponTypes type)
    {
        if (amount <= 0) {
            return 0;
        }
        int returnAmount = 0;
        if (type == CustomUtils.WeaponTypes.Shotgun) {
            if (amount >= shotgunAmmo) {
                returnAmount = shotgunAmmo;
                shotgunAmmo = 0;
            }  else {
                returnAmount = amount;
                shotgunAmmo -= amount;
            }
        }
        else if (type == CustomUtils.WeaponTypes.Rifle) {
            if (amount >= rifleAmmo) {
                returnAmount = rifleAmmo;
                rifleAmmo = 0;
            }
            else {
                returnAmount = amount;
                rifleAmmo -= amount;
            }
        }

        return returnAmount;
    }

    public void AddAmmo(int amount, CustomUtils.WeaponTypes type)
    {
        if (type == CustomUtils.WeaponTypes.Shotgun) {
            if (amount + shotgunAmmo >= maxShotgunAmmo) {
                shotgunAmmo = maxShotgunAmmo;
            } else {
                shotgunAmmo += amount;
            }
        }
        else if (type == CustomUtils.WeaponTypes.Rifle) {
            if (amount + rifleAmmo >= maxRifleAmmo) {
                rifleAmmo = maxRifleAmmo;
            }
            else {
                rifleAmmo += amount;
            }
        }
    }

}
