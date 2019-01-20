using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracksMouse : MonoBehaviour
{
    public Transform defaultTrack;

    private void Start()
    {
    }

    public void UpdateObj() {
        Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 currPos = transform.position;
        Vector2 diff = currMousePos - currPos;
        Vector3 desiredRotation;
        if (diff.magnitude >= 3  || defaultTrack == null) {
            float currAngle = transform.rotation.eulerAngles.z;
            float mouseAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            desiredRotation = new Vector3(0, 0, Mathf.LerpAngle(currAngle, mouseAngle, Time.deltaTime * 50));
        } else {
            if (defaultTrack != null)
                desiredRotation = defaultTrack.rotation.eulerAngles;
            else
                desiredRotation = transform.parent.rotation.eulerAngles;
        }
           
        //Debug.Log(temp);
        transform.eulerAngles = desiredRotation;
    }
}
