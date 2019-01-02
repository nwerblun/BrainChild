using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloadable : MonoBehaviour
{
    public CustomUtils.WeaponTypes type;
    //TODO reduce player's ammo by calling ammopool.take ammo
    AmmoPool pool;
    WeaponInfo info;
    Fireable fire;

    private float timeLeft = 0;
    public void Start()
    {
        fire = GetComponent<Fireable>();
        info = GetComponent<WeaponInfo>();
        pool = transform.parent.GetComponent<AmmoPool>();
    }

    public void Update()
    {
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
            fire.canFire = false;
        } else {
            fire.canFire = true;
        }
    }

    public void Reload()
    {
        timeLeft = info.reloadSpeed * info.reloadSpeedModifier;
        int amt = 0;
        if (info.ammoLeft > 0) {
            amt = pool.TakeAmmo(info.clipSize - info.ammoLeft, type);
        } else {
            amt = pool.TakeAmmo(info.clipSize, type);
        }

        info.ammoLeft += amt;
    }
}
