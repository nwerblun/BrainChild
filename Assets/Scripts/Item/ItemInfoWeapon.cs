using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoWeapon : ItemInfo
{

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void onPickup(GameObject player)
    {
        // add the value of the coin to the player's currency
        Debug.Log("RUN");
        player.GetComponent<Player>().SwitchWeapon(gameObject);
    }
}
