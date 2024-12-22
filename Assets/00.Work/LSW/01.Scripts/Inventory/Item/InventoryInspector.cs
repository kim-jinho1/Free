using System.Collections.Generic;
using UnityEngine;

public class InventoryInspector : MonoBehaviour
{
    private Slot mainSlot;
    private bool active;
    [SerializeField] private GameObject SpawnPos;

    private void OnEnable()
    {
        foreach (var item in InventoryManager.Instance.Slots)
            item.OnShowInspector += ShowInspector;
    }

    private void Update()
    {
        if(mainSlot != null)
        {
            switch (mainSlot._slotData.itemData.itemType)
            {
                case itemType.Equip:
                    if (mainSlot._slotData.equip)
                        InventoryManager.Instance._UseTxt.text = mainSlot.UnEquipTxt;
                    else
                        InventoryManager.Instance._UseTxt.text = mainSlot.EquipTxt;
                    break;
                case itemType.Using:
                    InventoryManager.Instance._UseTxt.text = mainSlot.UseTxt;
                    break;
                case itemType.Healing:
                    InventoryManager.Instance._UseTxt.text = mainSlot.HealTxt;
                    break;
            }
            if (Input.GetMouseButtonUp(0) && !mainSlot._isMousePointIn)
                Disable();
        }
    }

    private void ShowInspector(Slot slot)
    {
        mainSlot = slot;
        SpawnPos.GetComponent<RectTransform>().localPosition = InventoryManager.Instance.GetMousePos();

        active = true;
    }

    public void InspectorButton()
    {
        if (InventoryManager.Instance._inspector.activeSelf && mainSlot._slotData.state != State.Empty)
        {
            if (mainSlot._slotData.itemData.itemType == itemType.Equip)
                if (mainSlot._slotData.equip)
                    UnEquip(mainSlot);
                else
                    EquipItem();
            else if (mainSlot._slotData.itemData.itemType == itemType.Healing)
                HealItem();
            else if (mainSlot._slotData.itemData.itemType == itemType.Using)
                UseItem();
        }
    }

    public void DeleteItem()
    {
        mainSlot.Delete();
        Disable();
    }

    public void EquipItem()
    {
        if (!mainSlot._slotData.equip)
        {
            List<Slot> equipSlot = InventoryManager.Instance._equipSlots;
            if (!equipSlot.Exists(slot => slot._slotData.itemData.itemType == itemType.Equip                               //같은 Equip타입의 장착중인 아이템이 존재할 때
                && slot._slotData.itemData.equipType == mainSlot._slotData.itemData.equipType))
            {
                mainSlot._slotData.equip = InventoryManager.Instance.EquipItem(mainSlot);
            }
            else
            {
                Slot sameSlot = equipSlot.Find(slot => slot._slotData.itemData.itemType == itemType.Equip
                && slot._slotData.itemData.equipType == mainSlot._slotData.itemData.equipType);

                sameSlot._slotData.equip = InventoryManager.Instance.UnEquipItem(sameSlot);
                mainSlot._slotData.equip = InventoryManager.Instance.EquipItem(mainSlot);
            }
        }
        Disable();
    }

    public void UnEquip(Slot slot)
    {
        if(slot._slotData.equip)
        {
            InventoryManager.Instance.UnEquipItem(slot);
            Disable();
        }
    }

    private void HealItem()
    {
        //힐관련 플레이어 스텟 변화
        MonoSingleton<PlayerAbility>.Instance.IncreaseCurrentHp(
            mainSlot._slotData.itemData.HealthRateUp * MonoSingleton<PlayerAbility>.Instance.MaxHealth);
        MonoSingleton<PlayerAbility>.Instance.IncreaseCurrentHungry(
            mainSlot._slotData.itemData.HungerRateUp * MonoSingleton<PlayerAbility>.Instance.MaxHungry);
        mainSlot.Delete();
        Disable();
    }

    private void UseItem()
    {
        //디버프관련

        mainSlot.Delete();
        Disable();
    }

    public void Disable()
    {
        InventoryManager.Instance._inspector.SetActive(false);
    }

    private void OnDisable()
    {
        foreach (var item in InventoryManager.Instance.Slots)
            item.OnShowInspector -= ShowInspector;
    }

    private void OnApplicationQuit()
    {
        foreach (var item in InventoryManager.Instance.Slots)
            item.OnShowInspector -= ShowInspector;
    }

    private void ChkUseItemSort(ItemSort itemSort, Slot usingItem)
    {
        switch(itemSort)
        {
            case ItemSort.Attack:
                // 아이템 공격수치에 따른 현재 싸우는 적 체력 깍는 메소드
                // usingItem._slotData.itemData.Damage -=
                break;
            case ItemSort.PurifyDebuff:
                // 아이템 받아와서 아이템에 따라 디버프 해제하는 메소드
                break;
        }
    }
}
