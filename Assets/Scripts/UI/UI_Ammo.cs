using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ammo : MonoBehaviour
{
    

    private Text UI_ammo;

    private void Start()
    {
        UI_ammo = gameObject.GetComponent<Text>();
    }

    public void Update()
    {
        AmmoPool ap = GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoPool>();

        UI_ammo.text = 
            "Pistol:" + ap.pistolAmmo + 
            "\nShotgun:" + ap.shotgunAmmo +
            "\nRifle:" + ap.rifleAmmo;


    }
}
