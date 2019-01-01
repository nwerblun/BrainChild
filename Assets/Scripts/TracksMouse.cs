using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksMouse : MonoBehaviour
{
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;    
    }
    void Update() {
        Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        Vector2 diff = currMousePos - currPos;

        float currAngle = transform.rotation.eulerAngles.z;
        float mouseAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Vector3 desiredRotation;

        if (mouseAngle < 90 && mouseAngle > -90) {
            desiredRotation = new Vector3(0, 0, Mathf.LerpAngle(currAngle, mouseAngle, Time.deltaTime * 50));
            transform.localScale = originalScale;
        }
        else {
            desiredRotation = new Vector3(0, 0, Mathf.LerpAngle(currAngle, mouseAngle, Time.deltaTime * 50));
            transform.localScale = new Vector3(originalScale.x, -originalScale.y, originalScale.z);
        }
        //Debug.Log(angleDiff);
        transform.eulerAngles = desiredRotation;
    }
}
