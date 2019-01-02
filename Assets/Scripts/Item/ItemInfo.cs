using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemInfo : MonoBehaviour
{
    public bool isAnim;             // is there an animation of the item
    public bool isInteract;         // is there a need for user input to pick up

    public abstract void onPickup(GameObject player);
}
