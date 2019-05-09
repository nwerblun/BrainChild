using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float maxMoveSpeed;
    public GameObject weapon;
    public GameObject arm;
    public Animator body;
    private Rigidbody2D rb2d;                   //Player's rigid body needed to add velocity

    private Vector3 originalBodyScale;
    private Vector3 originalWeaponScale;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        originalBodyScale = body.transform.localScale;
        arm = transform.Find("Arm").gameObject;
        weapon = Instantiate(weapon, transform);
        originalWeaponScale = weapon.transform.localScale;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SwitchWeapon(GameObject newWeapon)
    {
        Destroy(weapon);
        weapon = Instantiate(newWeapon, transform);
        originalWeaponScale = weapon.transform.localScale;
    }

    public void setPlayerState(bool mode)
    {
        active = mode;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;

        if (active)
        {
            //Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Vector2 currPos = transform.position;
            //Vector2 diff = currMousePos - currPos;
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            Vector2 moveVector = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;
            arm.GetComponent<TracksMouse>().updateArm();
            weapon.transform.rotation = arm.transform.rotation;
            SetWeaponAnimationTriggers(moveHorizontal, moveVertical);
            rb2d.AddForce(moveVector);
            rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxMoveSpeed);
        }
        SetPlayerAnimationTriggers(moveHorizontal, moveVertical);
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

    private void SetPlayerAnimationTriggers(float moveHorizontal, float moveVertical)
    {
        if (moveHorizontal != 0) {
            if (moveHorizontal < 0) {
                body.transform.localScale = new Vector3(-originalBodyScale.x, originalBodyScale.y, originalBodyScale.z);
            } else {
                body.transform.localScale = originalBodyScale;
            }
            body.SetTrigger("GoingRightOrLeft");
        }
        else if (moveVertical > 0) {
            body.SetTrigger("GoingUp");
        }
        else if (moveVertical < 0) {
            body.SetTrigger("GoingDown");
        }
        else {
            body.SetTrigger("Stopped");
        }
    }

    private void SetWeaponAnimationTriggers(float moveHorizontal, float moveVertical)
    {
        Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = weapon.transform.position;
        Vector2 diff = currMousePos - currPos;
        weapon.transform.position = transform.Find("Arm").Find("Hand").position;
        if (Input.GetButton("Reload")) {
            weapon.GetComponent<Reloadable>().Reload();
        }

        if (moveHorizontal != 0) {
            //if (moveHorizontal < 0) {
            //    weapon.transform.localScale = new Vector3(-originalWeaponScale.x, originalWeaponScale.y, originalWeaponScale.z);
            //}
            //else {
            //    weapon.transform.localScale = originalWeaponScale;
            //}
            weapon.GetComponent<Animator>().SetTrigger("GoingRightOrLeft");
        }
        else if (moveVertical != 0) {
            weapon.GetComponent<Animator>().SetTrigger("GoingUpOrDown");
        }

        if (Input.GetButton("Fire1") && weapon.GetComponent<Fireable>().CanFire()) {
            weapon.GetComponent<Fireable>().Fire(diff);
            weapon.GetComponent<Animator>().SetBool("Shoot", true);
        } else {
            weapon.GetComponent<Animator>().SetBool("Shoot", false);
        }
    }
}
