using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO/EquipAble", fileName = "EquipItem")]
public class EquipAbleItemSO : ScriptableObject
{
    [Header("Item Info")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public ItemGrade Grade;

    #region ���Ⱥ�ȭ
    public int Attack; // ���ݷ�
    public int Speed; // �ӵ�
    public float Critical; // ġ��Ÿ��
    public float Dodge; // ȸ����
    public float PlusHP; // �ִ� HP ������
    public float PlusHunger; // �ִ� ����� ������
    #endregion
}
