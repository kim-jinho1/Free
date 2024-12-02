using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO/UseAble", fileName = "UseItem")]
public class UseAbleItemSO : ScriptableObject
{
    [Header("Item Info")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public ItemGrade Grade;

    public float AttackPercnet; // ���ݷ� �ݿ�(��ǻ� ����� ����)
}
