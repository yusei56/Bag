using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager_2 : MonoBehaviour
{
    static InventoryManager_2 instance;
    public Inventory myBag;//���������ݿ�
    public GameObject slotGrid;//��ʾ���ߵı�������UI
    public Slot slotPrefab;//���ӵ���UI
    public TMP_Text itemDescription;//��������
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
    }
    public static void UpdatedItemInfo(string itemInfo)
    {

        instance.itemDescription.text = itemInfo;
    }
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
            {
                break;
            }
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < 48; i++)
        {
            if (instance.myBag.itemOrderList.ContainsKey(i))
            {
                CreateNewItem(instance.myBag.itemOrderList[i]);
            }

        }
    }

    /// <summary>
    /// �����������仯��ˢ��ѡ��ı����ĵ�����ʾ
    /// </summary>
    /// <param name="bagNum"></param>  
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemNum.ToString();
        if (item.New)//��һ�����ֵĵ��߻���"New"�ı��
        {
            //newItem.newMark.enabled = true;
            newItem.newMark.gameObject.SetActive(true);
            //item.New = false;
        }
        //newItem.transform.localScale = new Vector3(1, 1, 1);
    }
}
