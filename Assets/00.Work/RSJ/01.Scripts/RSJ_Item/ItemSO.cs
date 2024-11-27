using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemSO")]
public class ItemSO : ScriptableObject
{
    [Header("Item Info")]
    public SpriteRenderer ItemImg;
    public string ItemName;
    public string ItemExplan;

    public ItemSort Sort;
    public ItemGrade Grade;
}
