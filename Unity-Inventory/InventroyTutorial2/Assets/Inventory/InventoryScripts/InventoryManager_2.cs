using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager_2 : MonoBehaviour
{
    static InventoryManager_2 instance;
    public Inventory myBag;//背包的数据库
    public GameObject gridGroup;//显示道具的背包格子UI
    public Slot slotPrefab;//格子道具UI
    public TMP_Text itemDescription;//道具描述
    int pages = 0;//背包当前所在页数
    // Start is called before the first frame update
    void Start()
    {
        foreach (Item item in myBag.itemList)
        {
            myBag.itemOrderList.Add(item.id, item);
        }
        
        InventoryManager_2.RefreshItem();
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
    public static void UpdatedItemInfo(string itemInfo)
    {
        //instance.scrollView.SetActive(true);
        instance.itemDescription.text = itemInfo;
    }
    public static void RefreshItem()
    {
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
                CreateNewItem(instance.myBag.itemOrderList[i]);
            }
        }
    }

    /// <summary>
    /// 当道具数量变化，刷新选择的背包的道具显示
    /// </summary>
    /// <param name="bagNum"></param>  
    public static void CreateNewItem(Item item)
    {
        int i = instance.myBag.itemList.Count/24;
        Slot newItem = Instantiate(instance.slotPrefab, instance.gridGroup.transform.GetChild(i).transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.gridGroup.transform.GetChild(i).transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemNum.ToString();
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
        if (pages < 4)
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
