using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RSJ_GetItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private List<ItemData> _ItemList;
    private List<ItemData> _getItemList = new List<ItemData>();

    public void OnPointerClick(PointerEventData eventData)
    {
        int RandomInt = Random.Range(0, 3);

        InventoryManager.Instance.AddItem(ItemChoose(RandomGrade(RandomInt)));

        _getItemList.Clear();
    }

    private ItemGrade RandomGrade(int percent)
    {
        switch (percent)
        {
            case 0:
                return ItemGrade.Common;
            case 1:
                return ItemGrade.Uncommon;
            case 2:
                return ItemGrade.Rare;
            case 3:
                return ItemGrade.Hero;
            case 4:
                return ItemGrade.Myth;
            default:
                return ItemGrade.Common;
        }
    }

    private ItemData ItemChoose(ItemGrade grade)
    {
        foreach (ItemData ran in _ItemList)
        {
            if (ran.itemGrade == grade)
            {
                _getItemList.Add(ran);
            }
        }

        int randomList = Random.Range(0, _getItemList.Count);
        Debug.Log(randomList);
        return _getItemList[randomList];
    }

   
}
