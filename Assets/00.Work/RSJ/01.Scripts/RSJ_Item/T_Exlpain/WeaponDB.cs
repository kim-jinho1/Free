using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponDB
{
    public static Dictionary<int, EquipAbleItemSO> ItemIDItemSODictionary = new Dictionary<int, EquipAbleItemSO>();

    public static void Instantiate()
    {
        var Item0 = new EquipAbleItemSO();
        Item0.ItemName = "���";
        Item0.ItemExplan = "������ ���ϴ�";

        ItemIDItemSODictionary.Add(0, Item0);


    }

    public static void ChangeState(float ChangeStat)
    {

    }
}



    /*
     *     [Header("������ ����")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public TempEnum MyEnum;
    public ItemGrade Grade;
     */
