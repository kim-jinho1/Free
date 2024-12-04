using DG.Tweening.Plugins.Options;
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player _player;
    public static InventoryManager Instance;
    public GameObject _inventory, _inventory_DisableButton, _inspector;
    public TextMeshProUGUI _UseTxt;

    [Header("Slot")]
    [SerializeField] private SlotData[] _slotData;
    public List<Slot> Slots = new List<Slot>(); // 아이템 목록
    [SerializeField] private GameObject _slotPrefabs, _slotParent;
    private int SlotFullValue = 0;

    [Header("Equip")]
    public List<Slot> _equipSlots = new List<Slot>();

    [Header("MovingItem")]
    public GameObject _slotMovePrefabs;
    public GameObject _slotChangeObject;
    public List<Slot> _eachChangeSlot = new List<Slot>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject slot = Instantiate(_slotPrefabs, _slotParent.transform);
            Slot slotScr = slot.GetComponentInChildren<Slot>();
            slotScr._slotData = _slotData[i];
            slotScr.ResetData();
            Slots.Add(slotScr);
        }
    }

    private void Update()
    {
        foreach(SlotData item in _slotData)
            if(item.itemData == null)
                 item.state = State.Empty;
            else
                 item.state = State.Full;

        if (MonoSingleton<PlayerAbility>.Instance.CurrentHungry > MonoSingleton<PlayerAbility>.Instance.MaxHungry)
            MonoSingleton<PlayerAbility>.Instance.CurrentHungry = 100;
        if (MonoSingleton<PlayerAbility>.Instance.CurrentHp > MonoSingleton<PlayerAbility>.Instance.MaxHealth)
            MonoSingleton<PlayerAbility>.Instance.CurrentHp = 100;
    }

    public void AddItem(ItemData newItem)       //아이템을 인벤토리에 추가
    {
        if (SlotFullValue < 20)
        {
            foreach (Slot slot in Slots)
            {
                if (slot._slotData.state == State.Empty)
                {
                    slot.AddItem(newItem);
                    return;
                }
            }
            Debug.Log("Inventory Slot Is Full");       //인벤토리 꽉참
        }
    }

    public void DeleteItem(Slot slot)       //아이템을 인벤토리에 제거
    {
        SlotFullValue--;
    }

    public bool EquipItem(Slot slot)       //아이템을 장착
    {
        _equipSlots.Add(slot);
        SetPlayerStat(slot._slotData.itemData);
        ShowEquipMark(slot);
        return true;
    }

    public bool UnEquipItem(Slot slot)      //아이템을 장착 해제
    {
        RollBackPlayerStat(slot._slotData.itemData);
        _equipSlots.Remove(slot);
        HideEquipMark(slot);
        slot._slotData.equip = false;
        return false;
    }

    public void ShowEquipMark(Slot Slot)
    {
        Slot._equipBorder.color = Color.red;
        Slot._equipMark.SetActive(true);
    }

    public void HideEquipMark(Slot Slot)
    {
        Slot._equipBorder.color = Color.black;
        Slot._equipMark.SetActive(false);
    }

    public void SetPlayerStat(ItemData item)
    {
        _player.AbilityData.attack += item.AttackUp;
        _player.AbilityData.dodge += item.DodgeRateUp;
        _player.AbilityData.accuracy += item.SpeedRateUp;
        _player.AbilityData.critical += item.CriticalUp;
        _player.AbilityData.maxHp += item.HealthRateUp;
        _player.AbilityData.maxHungry += item.HungerRateUp;
    }

    public void RollBackPlayerStat(ItemData item)
    {
        _player.AbilityData.attack -= item.AttackUp;
        _player.AbilityData.dodge -= item.DodgeRateUp;
        _player.AbilityData.accuracy -= item.SpeedRateUp;
        _player.AbilityData.critical -= item.CriticalUp;
        _player.AbilityData.maxHp -= item.HealthRateUp;
        _player.AbilityData.maxHungry -= item.HungerRateUp;
    }

    public Vector2 GetMousePos()
    {
        Vector2 mousePos = Input.mousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        InventoryManager.Instance._inventory.GetComponent<RectTransform>(),
        mousePos,
        null,
        out mousePos
        );
        return mousePos;
    }
}
