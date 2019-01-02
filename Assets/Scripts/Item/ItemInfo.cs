using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfo : MonoBehaviour
{
    public bool isAnim;             // is there an animation of the item

    public abstract void onPickup(GameObject player);
}
