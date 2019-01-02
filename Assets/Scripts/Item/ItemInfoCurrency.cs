using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfoCurrency : ItemInfo
{
    public uint value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void onPickup(GameObject player)
    {
        // add the value of the coin to the player's currency

        player.GetComponent<Inventory>().currency += value;
    }
}
