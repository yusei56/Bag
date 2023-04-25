using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Inventory playerInventory2;
    public Inventory playerInventory3;
    public Inventory playerInventory4;
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
        if (!bag.itemOrderList.ContainsKey(thisItem.id))//如果没持有相同类型的道具添加进背包
        {
            bag.itemList.Add(thisItem);
            bag.itemOrderList.Add(thisItem.id, thisItem);
            //InventoryManager.CreateNewItem(thisItem);
        }
        else//如果持有相同类型的道具数量加1
        {
            thisItem.itemNum += 1;
        }
        //InventoryManager.RefreshItem();
    }
}
