using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    //Has info about who shot it??
    public float projectileKnockback;
    public float initialDmg;
    public float projectileFalloff;
    public Vector2 initialLoc;
    public Transform originator;

    void OnCollisionEnter2D(Collision2D collision)
    {
        AffectedByProjectiles proj = collision.transform.GetComponent<AffectedByProjectiles>();
        if (proj != null) {
            Debug.Log("HIT " + collision.transform.name);
            proj.TakeHit(ComputeDamage());
            proj.TakeKnockback(ComputeForce());
        }
        Destroy(gameObject);
    }

    private float ComputeDamage()
    {
        return initialDmg - (projectileFalloff * (initialLoc - (Vector2)transform.position).magnitude);
    }

    private Vector2 ComputeForce()
    {
        Rigidbody2D rb2d = transform.GetComponent<Rigidbody2D>();
        return rb2d.velocity.normalized * projectileKnockback;
    }
}
