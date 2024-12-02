using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponDB
{
    public static Dictionary<int, EquipAbleItemSO> ItemIDItemSODictionary = new Dictionary<int, EquipAbleItemSO>();

    public static void Instantiate()
    {
        var Item0 = new EquipAbleItemSO();
        Item0.ItemName = "대검";
        Item0.ItemExplan = "설명이 들어갑니다";

        ItemIDItemSODictionary.Add(0, Item0);


    }

    public static void ChangeState(float ChangeStat)
    {

    }
}



    /*
     *     [Header("아이템 정보")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public TempEnum MyEnum;
    public ItemGrade Grade;
     */
