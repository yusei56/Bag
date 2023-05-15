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
    public SpecItemInfo specItemInfo;//特殊物品的信息显示
    private float timer;//计时
    private bool timeStart;//是否开始计时
    public GameObject specItemButton;//特定目标互动道具按钮
    public bool targetExist;//特定目标是否存在
    public GameObject NoTargrtButton;//无特定目标按钮
    private void Start()
    {
        targetExist = false;
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
                PassivelyUsed();
                AddNewItem(playerInventory);
                InventoryManager.RefreshItem();
            }
            else if (thisItem.itemType == 2)
            {  NoTargrtButton.SetActive(true);
                timeStart = true;//开始计时
                InfoDisplay(thisItem,specItemInfo);//对特殊消耗类道具在上方显示缩小图标和说明信息栏
                AddNewItem(playerInventory2);
                InventoryManager_2.RefreshItem();
            }
            else if (thisItem.itemType == 3)
            {
                if(targetExist)
                    specItemButton.SetActive(true);
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
            if (!bag.itemOrderList.ContainsKey(thisItem.id))//如果没持有相同类型的道具添加进背包
            {
                thisItem.itemNum = itemHeld;
                bag.itemList.Add(thisItem);
                bag.itemOrderList.Add(thisItem.id, thisItem);
                //InventoryManager.CreateNewItem(thisItem);
            }
            else//如果持有相同类型的道具数量加1
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
    public void PassivelyUsed()
    {//被动类型道具使用
        Debug.Log("物品直接生效");
    }
    public void specUsed()
    { 
    //对特定目标使用该物品
      targetExist = false;
        if (thisItem.itemNum > 1)
            thisItem.itemNum--;
        else
        {
            playerInventory3.itemList.Remove(thisItem);
            playerInventory3.itemOrderList.Remove(thisItem.id);
        }
    }
    public void noTargetButton()
    { 
        //无特定目标物品被使用
    }
}
