using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health : MonoBehaviour
{
    
    private int health = 100;                       // need to reference the players health 

    private Text UI_health;

    private void Start()
    {
        UI_health = gameObject.GetComponent<Text>();
    }
    private void Update()
    {
        UI_health.text = "HP : " + health;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            health--;
        }
    }
}
