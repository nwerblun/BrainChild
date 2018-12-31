using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Collision : MonoBehaviour
{
    public static string objectName = "";

    private Text UI_collision;

    public static void setFlag(string name)
    {
        Debug.Log("WHY: " + name);
        objectName = name;
    }

    private void Start()
    {
        UI_collision = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        UI_collision.text = "Collision: " + objectName;
    }
}
