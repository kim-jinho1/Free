using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SJ_ItemUnD : PlayerAbility
{
    private ItemSO _usingType;

    public void EquipOrUse()
    {
        ItemCheck();
    }

    public void DisCard()
    {

    }

    private void ItemCheck()
    {
        switch(_usingType.Sort)
        {
            case (ItemSort.Equip):
                break;
            case (ItemSort.Using):
                break;
            case (ItemSort.Healing):
                Healing();
                break;
        }
    }

    public void Healing()
    {

    }
}
