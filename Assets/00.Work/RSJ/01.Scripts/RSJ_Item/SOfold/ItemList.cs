using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemList", fileName = "List")]
public class ItemList : ScriptableObject
{
    public List<EquipAbleItemSO> _EquipList;
    public List<HealAbleItemSO> _HealList;
    public List<UseAbleItemSO> _UseList;
}
