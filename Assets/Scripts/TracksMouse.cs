using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksMouse : MonoBehaviour
{
    void Update() {
        Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        Vector2 diff = currMousePos - currPos;

        float currAngle = transform.rotation.eulerAngles.z;
        float mouseAngle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);

        Vector3 desiredRotation = new Vector3(0, 0, Mathf.LerpAngle(currAngle, mouseAngle, Time.deltaTime * 50));        
        //Debug.Log(angleDiff);
        transform.eulerAngles = desiredRotation;
    }
}
