using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Add Require component for player info which will have HP, etc.
public class AffectedByProjectiles : MonoBehaviour
{
    public void TakeHit(float amt)
    {
        CharacterInfo info = transform.GetComponent<CharacterInfo>();
        if (info != null)
        {
            info.TakeHit(amt);
        }
    }

    public void AddHp(float amt)
    {
        CharacterInfo info = transform.GetComponent<CharacterInfo>();
        if (info != null)
        {
            info.AddHp(amt);
        }
    }

    public void TakeKnockback(Vector2 force)
    {
        Rigidbody2D rb2d = transform.GetComponent<Rigidbody2D>();
        if (transform != null && rb2d != null)
        {
            rb2d.AddForce(force, ForceMode2D.Impulse);
        }
    }


}
