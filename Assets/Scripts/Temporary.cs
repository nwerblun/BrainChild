using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float timeToDelete;
    public float maxTravelDistance;
    public Vector2 startPos;
    void Update()
    {
        if (timeToDelete > 0)
            timeToDelete -= Time.deltaTime;
        else
            Destroy(gameObject);

        Vector2 traveled = (Vector2)transform.position - startPos;
        if (maxTravelDistance > 0 && traveled.magnitude >= maxTravelDistance)
            Destroy(gameObject);
    }
}
