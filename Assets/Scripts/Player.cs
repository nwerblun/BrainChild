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
        Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        Vector2 diff = currMousePos - currPos;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 moveVector = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        if (Input.GetButton("Fire1")) {
            weapon.GetComponent<Fireable>().Fire(diff);
        }

        if (Input.GetButton("Reload")) {
            weapon.GetComponent<Reloadable>().Reload();
        }

        rb2d.AddForce(moveVector);
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxMoveSpeed);
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
