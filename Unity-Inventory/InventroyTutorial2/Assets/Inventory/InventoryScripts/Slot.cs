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
        InventoryManager.UpdatedItemInfo(slotItem.itemInfo);
    }
}

