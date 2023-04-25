using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * 控制单个道具格子的显示
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
    /// 根据选中的道具更新道具信息的显示
    /// </summary>
    public void ItemOnClicked()
    {
        //newMark.enabled = false;
        newMark.gameObject.SetActive(false);//点击道具"New"标记会消失
        slotItem.New = false;
        InventoryManager.UpdatedItemInfo(slotItem.itemInfo);
    }
}

