using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float maxMoveSpeed;
    public GameObject weapon;
    public Animator body;
    public Animator arms;
    private Rigidbody2D rb2d;                   //Player's rigid body needed to add velocity

    private Vector3 originalBodyScale;
    private Vector3 originalArmScale;

    // Start is called before the first frame update
    void Start()
    {
        originalArmScale = arms.transform.localScale;
        originalBodyScale = body.transform.localScale;
        //weapon = Instantiate(weapon, transform);
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SwitchWeapon(GameObject newWeapon)
    {
        Destroy(weapon);
        weapon = Instantiate(newWeapon, transform);
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

        SetAnimationTriggers(moveHorizontal, moveVertical);

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

    private void SetAnimationTriggers(float moveHorizontal, float moveVertical)
    {
        Vector3 armDown = new Vector3(-1.02f, 0.75f, 0);
        Vector3 armRight = new Vector3(1f, 1f, 0);
        Vector3 armLeft = new Vector3(-2.68f, 1f, 0);
        Vector3 armUp = new Vector3(-1.02f, 1.75f, 0);


        if (moveHorizontal != 0) {
            if (moveHorizontal < 0) {
                arms.transform.localPosition = armLeft;
                body.transform.localScale = new Vector3(-originalBodyScale.x, originalBodyScale.y, originalBodyScale.z);
                arms.transform.localScale = new Vector3(-originalArmScale.x, originalArmScale.y, originalArmScale.z);
            } else {
                arms.transform.localPosition = armRight;
                body.transform.localScale = originalBodyScale;
                arms.transform.localScale = originalArmScale;
            }
            body.SetTrigger("GoingRightOrLeft");
            arms.SetTrigger("GoingRightOrLeft");
        }
        else if (moveVertical > 0) {
            arms.transform.localPosition = armUp;
            body.SetTrigger("GoingUp");
            arms.SetTrigger("GoingUp");
        }
        else if (moveVertical < 0) {
            arms.transform.localPosition = armDown;
            body.SetTrigger("GoingDown");
            arms.SetTrigger("GoingDown");
        }
        else {
            body.SetTrigger("Stopped");
            arms.SetTrigger("Stopped");
        }
    }
}
