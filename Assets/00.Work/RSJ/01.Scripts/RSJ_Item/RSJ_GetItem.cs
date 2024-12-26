using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RSJ_GetItem : MonoBehaviour, IPointerClickHandler, IAttackAble
{
    [SerializeField] private List<ItemData> _ItemList;
    private List<ItemData> _getItemList = new List<ItemData>();
    [SerializeField] private Transform[] _ItemPos;

    private void Awake()
    {
        int spawnDone = 0;
        for (int i = 0; i < _ItemPos.Length; i++)
        {
            int spawnRandomInt = Random.Range(0,2);

            if (spawnRandomInt == 1)
            {
                _ItemPos[i].gameObject.SetActive(true);
                spawnDone++;
            }
            else if (spawnDone == 2)
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int RandomInt = Random.Range(0, 3);

        InventoryManager.Instance.AddItem(ItemChoose(RandomGrade(RandomInt)));

        _getItemList.Clear();

        eventData.pointerCurrentRaycast.gameObject.SetActive(false);
    }

    private ItemGrade RandomGrade(int percent)
    {
        switch (percent)
        {
            case 0:
                return ItemGrade.Common;
            case 1:
                return ItemGrade.Uncommon;
            case 2:
                return ItemGrade.Rare;
            case 3:
                return ItemGrade.Hero;
            case 4:
                return ItemGrade.Myth;
            default:
                return ItemGrade.Common;
        }
    }

    private ItemData ItemChoose(ItemGrade grade)
    {
        foreach (ItemData ran in _ItemList)
        {
            if (ran.itemGrade == grade)
            {
                _getItemList.Add(ran);
            }
        }

        int randomList = Random.Range(0, _getItemList.Count);
        return _getItemList[randomList];
    }

    public void AttackEnemy(EnemyData enemy, ItemData item)
    {
        Debug.Log("사용시 공격 가능");
        //enemy -= item.AttackUp;
    }
}
