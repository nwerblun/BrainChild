using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Collision : MonoBehaviour
{
    public static string objectName = "";

    public Text UI_collision;

    public static void setFlag(string objectName)
    {
        UI_Collision.objectName = objectName;
    }

    // Update is called once per frame
    private void Update()
    {
        if (objectName != "")
            UI_collision.text = "Collision: " + objectName;
        else
            UI_collision.text = "Collision:";
    }
}
