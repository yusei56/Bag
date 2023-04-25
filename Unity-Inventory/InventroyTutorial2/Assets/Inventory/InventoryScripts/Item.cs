using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public int id;
    public int itemId;
    public int itemType;
    public string itemName;
    [TextArea]
    public string itemInfo;

    public Sprite itemImage;
    public int itemNum;//���߳�����

    public bool New = true;//ȷ���ǲ����µ���
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
