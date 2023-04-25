using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();//�洢�������е��ߵ�����
    public Dictionary<int, Item> itemOrderList = new Dictionary<int, Item>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

