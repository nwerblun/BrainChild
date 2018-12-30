using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInfo : MonoBehaviour
{
    //Has info about how much damage it does
    //Has info about who shot it??


    private void Start()
    {
        Debug.Log("Done");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");

        Destroy(gameObject);
    }
}
