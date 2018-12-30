using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    /* Has a bunch of variables
     * base damage
     * damage multiplier
     * fire rate
     * bulletspershot
     * bullet per shot mod
     * bullet speed
     * bullet speed modifier
     * fire rate modifier
     * reload modifier
     * reload speed
     * clip size
     * clip size modifier
     * ammo in clip
     * ammo that gun uses
     */

    public float base_dmg;
    public float dmg_modifier;

    public float fire_rate;                           // In terms of time till new shot can be fired
    public float fire_rate_modifier;

    public float reload_speed;                      // In terms of how long the reload animations takes
    public float reload_speed_modifier;

    public int bullets_per_shot;
    public float bullet_per_shot_modifier;

    public float bullet_spread;                     // aka accuracy

    public float bullet_speed;
    public float bullet_speed_modifier;

    public int clip_size;
    public float clip_size_modifier;

    public int ammo_left;

    // I want to add item cost in terms of $$$. Doesnt seem like it belongs here. Maybe we still have an item class?

    private void Start()
    {
        fire_rate = 1 / fire_rate;
    }

}
