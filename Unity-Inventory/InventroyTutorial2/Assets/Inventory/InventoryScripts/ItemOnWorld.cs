using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public int itemHeld;
    public Inventory playerInventory;
    public Inventory playerInventory2;
    public Inventory playerInventory3;
    public Inventory playerInventory4;
    public SpecItemInfo specItemInfo;//������Ʒ����Ϣ��ʾ
    private float timer;//��ʱ
    private bool timeStart;//�Ƿ�ʼ��ʱ
    private void Start()
    {
        specItemInfo.itemImage = null;
        specItemInfo.desciption.text = "";
        timeStart = false;
        timer = 0f;
    }
    private void Update()
    {
        if (timeStart)
        {
            timer += Time.deltaTime;
            if(timer > 2)
            {
                specItemInfo.itemImage = null;
                specItemInfo.desciption.text = "";
                timeStart=false;
                timer = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (thisItem.itemType == 1)
            {
                AddNewItem(playerInventory);
                InventoryManager.RefreshItem();
            }
            else if (thisItem.itemType == 2)
            {  
                timeStart = true;
                InfoDisplay(thisItem,specItemInfo);
                AddNewItem(playerInventory2);
                InventoryManager_2.RefreshItem();
            }
            else if (thisItem.itemType == 3)
            {
                AddNewItem(playerInventory3);
                InventoryManager_3.RefreshItem();
            }
            else if (thisItem.itemType == 4)
            {
                AddNewItem(playerInventory4);
                InventoryManager_4.RefreshItem();
            }

            Destroy(gameObject);
        }
    }


    public void AddNewItem(Inventory bag)
    {
        {
            if (!bag.itemOrderList.ContainsKey(thisItem.id))//���û������ͬ���͵ĵ�����ӽ�����
            {
                thisItem.itemNum = itemHeld;
                bag.itemList.Add(thisItem);
                bag.itemOrderList.Add(thisItem.id, thisItem);
                //InventoryManager.CreateNewItem(thisItem);
            }
            else//���������ͬ���͵ĵ���������1
            {
                thisItem.itemNum += itemHeld;
            }
        }
        //InventoryManager.RefreshItem();
    }
    private void InfoDisplay(Item item,SpecItemInfo specItemInfo)
    {
            specItemInfo.itemImage.sprite = item.itemImage;
            specItemInfo.desciption.text = item.itemInfo;
    }
}
