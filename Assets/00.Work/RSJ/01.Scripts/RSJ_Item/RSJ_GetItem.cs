using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RSJ_GetItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private ItemList _itemList;

    public void OnPointerClick(PointerEventData eventData)
    {
        int RandomInt = Random.Range(0, 3);

        switch (RandomInt)
        {
            case 0:
                int RandomEquip = Random.Range(0, _itemList._EquipList.Count);
                Debug.Log("È¹µæ" + _itemList._EquipList[RandomEquip].ItemName);
                break;
            case 1:
                int RandomUse = Random.Range(0, _itemList._UseList.Count);
                Debug.Log("È¹µæ" + _itemList._UseList[RandomUse].ItemName);
                break;
            case 2:
                int RandomHeal = Random.Range(0, _itemList._HealList.Count);
                Debug.Log("È¹µæ" + _itemList._HealList[RandomHeal].ItemName);
                break;
        }
    }
}
