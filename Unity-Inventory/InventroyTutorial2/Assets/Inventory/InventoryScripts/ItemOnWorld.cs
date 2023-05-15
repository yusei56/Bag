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
    public GameObject specItemButton;//�ض�Ŀ�껥�����߰�ť
    public bool targetExist;//�ض�Ŀ���Ƿ����
    public GameObject NoTargrtButton;//���ض�Ŀ�갴ť
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
                timeStart = true;//��ʼ��ʱ
                InfoDisplay(thisItem,specItemInfo);//������������������Ϸ���ʾ��Сͼ���˵����Ϣ��
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
    public void PassivelyUsed()
    {//�������͵���ʹ��
        Debug.Log("��Ʒֱ����Ч");
    }
    public void specUsed()
    { 
    //���ض�Ŀ��ʹ�ø���Ʒ
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
        //���ض�Ŀ����Ʒ��ʹ��
    }
}
