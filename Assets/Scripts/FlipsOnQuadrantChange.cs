using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipsOnQuadrantChange : MonoBehaviour
{
    private Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(originalScale);
        float currAngle = transform.rotation.eulerAngles.z;
        int quad = GetQuadrant(currAngle);
        if (quad == 4 || quad == 1) {
            transform.localScale = originalScale;
        }
        else {
            transform.localScale = new Vector3(originalScale.x, -originalScale.y, originalScale.z);
        }
    }

    private int GetQuadrant(float currAngle)
    {
        if ((currAngle >= 0.0 && currAngle <= 90.0) || (currAngle <= -270.0 && currAngle >= -360.0)) {
            return 1;
        } else if ((currAngle > 90.0 && currAngle <= 180.0) || (currAngle <= -180.0 && currAngle > -270.0)) {
            return 2;
        } else if ((currAngle > 180.0 && currAngle <= 270.0) || (currAngle <= -90.0 && currAngle > -180.0)) {
            return 3;
        } else {
            return 4;
        }
    }
}
