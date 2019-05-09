using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public uint currency;

    public List<GameObject> list;

    public GameObject g1;
    public GameObject g2;

    private void Start()
    {
        list = new List<GameObject>();

        list.Add(g1);
        list.Add(g2);
    }
}
