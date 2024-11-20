using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UseInspector : Slot
{
    public void TryUse()
    {
        if (_inspector.activeSelf && _state != State.Empty)
        {
            if (_itemData.itemType == itemType.Equip)
                EquipItem();
            if (_itemData.itemType == itemType.Healing)
                HealItem();
            if (_itemData.itemType == itemType.Using)
                UseItem();
        }
    }

    private void EquipItem()
    {
        if (!equip)
            equip = InventoryManager.Instance.EquipItem(_itemData);
        else if (equip)
            equip = InventoryManager.Instance.UnEquipItem(_itemData);

        _equipMark.color = equip ? Color.red : Color.black;
    }

    private void HealItem()
    {
        
    }

    private void UseItem()
    {
        
    }

    public void DeleteItem()
    {
        Delete();
    }
}
