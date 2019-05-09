using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public float x;
    public float y;
    GameObject img1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // parse through the list from inventory and display in an image panel
    // max amount of inventory space
    // Figure out a way to use a prefab with out instantiating it. Use IDs?
    // ID finds the prefab and pulls the information. Dont need to instantiate anything?

    public void Display()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        img1 = new GameObject();
        Image img = img1.AddComponent<Image>();

        img1.transform.parent = gameObject.transform;
        img.sprite = player.GetComponent<Inventory>().list[0].GetComponent<SpriteRenderer>().sprite;

        //img1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        

    }

    private void Update()
    {
        //img1.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
        //Debug.Log(img1.GetComponent<RectTransform>().)
    }
}
