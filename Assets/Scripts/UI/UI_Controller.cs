using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    private GameObject gameHUD;
    private GameObject inventoryHUD;

    private enum States
    {
        stateGame,
        stateInventory
    };

    // booleans to permit state change
    private States state;

    private bool inventory;
    private bool game;

    // Start is called before the first frame update
    void Start()
    {
        gameHUD = transform.Find("UI_GameHUD").gameObject;
        inventoryHUD = transform.Find("UI_InventoryHUD").gameObject;

        inventory = true;
        game = true;

        gameHUD.SetActive(true);
        inventoryHUD.SetActive(false);

        state = States.stateGame;
    }

    // Update is called once per frame
    void Update()
    {
        // turn on inventory screen
        if(Input.GetKeyUp("tab") && inventory)
        {
            // if in the inventory state change to game
            if(state == States.stateInventory)
            {
                Cursor.visible = false;
                gameHUD.SetActive(true);
                inventoryHUD.SetActive(false);
                state = States.stateGame;
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Player>().setPlayerState(true);
            }

            // change to inventory state
            else
            {
                Cursor.visible = true;
                gameHUD.SetActive(false);
                inventoryHUD.SetActive(true);
                state = States.stateInventory;
                inventoryHUD.transform.Find("Panel").gameObject.GetComponent<DisplayInventory>().Display();
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<Player>().setPlayerState(false);

            }
        }
    }
}
