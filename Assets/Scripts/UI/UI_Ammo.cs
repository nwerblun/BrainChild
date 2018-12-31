using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Ammo : MonoBehaviour
{
    private int shotgunAmmo = 100;                       // need to reference the players ammo here

    private Text UI_ammo;

    private void Start()
    {
        UI_ammo = gameObject.GetComponent<Text>();
    }

    public void Update()
    {
        UI_ammo.text = "Shotgun :" + shotgunAmmo;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shotgunAmmo--;
        }
    }
}
