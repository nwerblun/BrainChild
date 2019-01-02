using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{

    public GameObject item;
    private SpriteRenderer sprite;
    private PolygonCollider2D polyCollider;

    private Animator animator;

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = item.GetComponent<SpriteRenderer>().sprite;


        // create poly collider
        polyCollider = gameObject.AddComponent<PolygonCollider2D>();
        polyCollider.isTrigger = true;

        // check if there is an animation
        if(item.GetComponent<ItemInfo>().isAnim)
        {
            animator = gameObject.AddComponent<Animator>();
            animator.runtimeAnimatorController = item.GetComponent<Animator>().runtimeAnimatorController;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Coin Touched");

            // general item pick up collider ...
            // call the prefabs pick up method.

            item.GetComponent<ItemInfo>().onPickup(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
