using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager_3 : MonoBehaviour
{
    static InventoryManager_3 instance;
    public Inventory myBag;//背包的数据库
    public GameObject gridGroup;//显示道具的背包格子UI
    public Slot slotPrefab;//格子道具UI
    public TMP_Text itemDescription;//道具描述
    int pages = 0;//背包当前所在页数
    int totalCount;//存储物品所需格子
    public TMP_Text itemName;//物品名字
    public GameObject fullAlarm;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Item item in myBag.itemList)
        {
            myBag.itemOrderList.Add(item.id, item);
        }
        
        InventoryManager_3.RefreshItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
    }
    private void OnEnable()
    {
        RefreshItem();
        instance.itemDescription.text = "";
        //instance.scrollView.SetActive(false);
    }
    public static void UpdatedItemInfo(Item item)
    {
        //instance.scrollView.SetActive(true);
        instance.itemDescription.text = item.itemInfo;
        instance.itemName.text = item.itemName;
    }
    public static void RefreshItem()
    {
        instance.totalCount = 0;
        for (int i = 0; i < instance.gridGroup.transform.childCount; i++)
        {
            for (int j = 0; j < instance.gridGroup.transform.GetChild(i).childCount; j++)
            {
                if (instance.gridGroup.transform.GetChild(i).childCount == 0)
                {
                    break;
                }
                Destroy(instance.gridGroup.transform.GetChild(i).transform.GetChild(j).gameObject);//初始化gridGroup
            }
        }
        for (int i = 0; i < 72; i++)
        {
            if (instance.myBag.itemOrderList.ContainsKey(i))
            {
                for (int j = instance.myBag.itemOrderList[i].itemNum; j > 0; j++)
                {
                    if (instance.totalCount >= 72)
                    {
                        instance.fullAlarm.SetActive(true);
                        break;
                    }
                    else
                    {
                        instance.fullAlarm.SetActive(false);
                        if (j > 99)
                        {
                            CreateNewItem(instance.myBag.itemOrderList[i], 99);
                            instance.totalCount++;
                        }
                        else
                        {
                            CreateNewItem(instance.myBag.itemOrderList[i], j);
                            instance.totalCount++;
                        }
                        j -= 99;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 当道具数量变化，刷新选择的背包的道具显示
    /// </summary>
    /// <param name="bagNum"></param>  
    public static void CreateNewItem(Item item,int Num)
    {
        int i = instance.totalCount / 24;
        Slot newItem = Instantiate(instance.slotPrefab, instance.gridGroup.transform.GetChild(i).transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.gridGroup.transform.GetChild(i).transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = Num.ToString();
        if (item.New)//第一次入手的道具会有"New"的标记
        {
            //newItem.newMark.enabled = true;
            newItem.newMark.gameObject.SetActive(true);
            //item.New = false;
        }
        //newItem.transform.localScale = new Vector3(1, 1, 1);
    }
    public void RightOnClicked()
    {
        if (pages <2)
        { pages++; }
        for (int i = 0; i < instance.gridGroup.transform.childCount; i++)
        {
            if (i == pages)
                instance.gridGroup.transform.GetChild(i).gameObject.SetActive(true);
            else
                instance.gridGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void LeftOnClicked()
    {
        if (pages > 0)
        { pages--; }
        for (int i = 0; i < instance.gridGroup.transform.childCount; i++)
        {
            if (i == pages)
                instance.gridGroup.transform.GetChild(i).gameObject.SetActive(true);
            else
                instance.gridGroup.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
