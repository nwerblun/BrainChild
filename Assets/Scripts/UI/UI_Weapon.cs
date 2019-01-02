using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Weapon : MonoBehaviour
{
    private Text UI_weapon;

    private void Start()
    {
        UI_weapon = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        WeaponInfo wi = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().weapon.GetComponent<WeaponInfo>();
        UI_weapon.text = "Ammo: " + wi.ammoLeft + "/" + wi.clipSize;
    }
}
