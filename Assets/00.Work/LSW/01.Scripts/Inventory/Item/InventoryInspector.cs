using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEditor;

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
        if(mainSlot != null)
        {
            if (InventoryManager.Instance._inspector.activeSelf && mainSlot._slotData.state != State.Empty)
            {
                if (mainSlot._slotData.itemData.itemType == itemType.Equip)
                    if (mainSlot._slotData.equip)
                        UnEquip(mainSlot);
                    else
                        EquipItem();
                if (mainSlot._slotData.itemData.itemType == itemType.Healing)
                    HealItem();
                if (mainSlot._slotData.itemData.itemType == itemType.Using)
                    UseItem();
            }
        }
    }

    public void DeleteItem()
    {
        mainSlot.Delete();
        Disable();
    }

    public void EquipItem()
    {
        InventoryManager.Instance.Equip(mainSlot);
        Disable();
    }

    public void UnEquip(Slot slot)
    {
        InventoryManager.Instance.UnEquipItem(slot);
        Disable();
    }

    private void HealItem()
    {
        //힐관련 플레이어 스텟 변화
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
}
