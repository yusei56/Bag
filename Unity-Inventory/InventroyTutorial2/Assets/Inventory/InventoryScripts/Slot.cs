using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * ���Ƶ������߸��ӵ���ʾ
 * 
 */
public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public TMP_Text slotNum;
    public TMP_Text newMark;
    public int slotType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ����ѡ�еĵ��߸��µ�����Ϣ����ʾ
    /// </summary>
    public void ItemOnClicked()
    {
        //newMark.enabled = false;
        newMark.gameObject.SetActive(false);//�������"New"��ǻ���ʧ
        slotItem.New = false;
        if(slotType == 1)
        InventoryManager.UpdatedItemInfo(slotItem.itemInfo);
        else if(slotType == 2)
        InventoryManager_2.UpdatedItemInfo(slotItem.itemInfo);
        else if(slotType==3)
            InventoryManager_3.UpdatedItemInfo(slotItem.itemInfo);
        else if(slotType==4)
            InventoryManager_4.UpdatedItemInfo(slotItem.itemInfo);
    }
    private void OnDisable()
    {
        if (slotType == 1)
            InventoryManager.UpdatedItemInfo("");
        else if (slotType == 2)
            InventoryManager_2.UpdatedItemInfo("");
        else if( slotType == 3)
        InventoryManager_3.UpdatedItemInfo("");
        else if (slotType == 4)
            InventoryManager_4.UpdatedItemInfo("");
    }
}

