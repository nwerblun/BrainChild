using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDrawer : MonoBehaviour
{
    public Transform drawStartLoc;
    public float maxLineRenderDist;
    private LineRenderer line;
    private int layerMask;
    private Transform start;
    void Start()
    {
        if (drawStartLoc != null)
            start = drawStartLoc;
        else
            start = transform;
        layerMask = ~(1 << LayerMask.NameToLayer("PlayerLayer"));
        line = transform.GetComponent<LineRenderer>();
        line.positionCount = 2;
    }
    void Update()
    {
        //Thanks Derek for the idea
        float rot = start.rotation.eulerAngles.z;
        //Rotate a unit vector to be in the direction of the gun
        Vector2 final = Quaternion.Euler(0, 0, rot) * Vector2.right;
        //Cast a ray in this direction to check for collision
        RaycastHit2D hit = Physics2D.Raycast(start.position, final, Mathf.Infinity, layerMask);
        //Now translate the vector to be at the chosen location
        final = (Vector2)start.position + final * maxLineRenderDist;
        //Draw lines
        Vector2 lerpedStart = Vector2.Lerp(line.GetPosition(0), start.position, Time.deltaTime * 250);
        line.SetPosition(0, lerpedStart);

        if (hit.collider != null) 
            //If it hits, then set the end draw point of the line to where it collided
             final = hit.point;

        Vector2 lerpedFinal = Vector2.Lerp(line.GetPosition(1), final, Time.deltaTime * 250);
        line.SetPosition(1, lerpedFinal);
    }
}
