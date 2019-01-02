using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Currency : MonoBehaviour
{
    private uint currency;

    private Text UI_currency;

    // Start is called before the first frame update
    private void Start()
    {
        UI_currency = gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        currency = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().currency;
        UI_currency.text = "Currency: $" + currency;
    }
}
