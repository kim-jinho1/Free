using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemGrade/Rare", fileName = "RareItemFrame")]
public class RSJ_RareItem : ScriptableObject
{
    public SpriteRenderer _img;
    public string _itemName;
    public string _itemExplain;

    public ItemSort _itemSort;

    [Header("���Ⱥ�ȭ����")]
    #region ���Ⱥ�ȭ����
    public int _Attack;
    public int _Speed;
    public int _DodgePer;
    public int _CriticalPer;
    public float PlusHP;
    public float PlusHunger;
    #endregion
}
