using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float maxMoveSpeed;
    public GameObject weapon;

    private Rigidbody2D rb2d;                   //Player's rigid body needed to add velocity

    // Start is called before the first frame update
    void Start()
    {
        weapon = Instantiate(weapon, transform);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire1")) {
            weapon.GetComponent<Fireable>().Fire();
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement = movement * moveSpeed;

        rb2d.velocity = new Vector2(Mathf.Clamp(movement.x, -maxMoveSpeed, maxMoveSpeed), Mathf.Clamp(movement.y, -maxMoveSpeed, maxMoveSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        UI_Collision.setFlag("");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        UI_Collision.setFlag(collision.gameObject.name);
    }
}
