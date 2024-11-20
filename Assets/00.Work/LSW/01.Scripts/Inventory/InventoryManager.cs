using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player _player;
    public static InventoryManager Instance;

    [Header("Slot")]
    public List<Slot> Slots = new List<Slot>(); // 아이템 목록
    [SerializeField] private GameObject _slotPrefabs, _slotParent;
    private int SlotFullValue = 0;
    public bool OnActive = false;

    [Header("Message")]
    [SerializeField] private GameObject _messageUI;
    public float _messageDisapearTime;
    public string _inventFullMessage = "CanGetItem!!\n(Inventory is full)";
    private bool MessageShow = false;

    [Header("Equip")]
    private List<ItemData> equipItems = new List<ItemData>();

    [Header("MovingItem")]
    public GameObject _movingItem;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        _messageUI.SetActive(false);
    }

    private void Start()
    {
        for(int i = 0; i < 20; i ++)
        {
            GameObject slot = Instantiate(_slotPrefabs, _slotParent.transform);
            Slots.Add(slot.GetComponentInChildren<Slot>());
        }
    }

    private void Update()
    {
        if (MessageShow)
        {
            if (Input.GetMouseButtonDown(0))
                Disable();
        }
    }

    public void Active()
    {
        OnActive = !OnActive;
        if (OnActive)
            _slotParent.SetActive(true);
        else
            _slotParent.SetActive(false);
    }

    public void AddItem(ItemData newItem)       //아이템을 인벤토리에 추가
    {
        if(SlotFullValue >= 20)
        {
            ShowUIMessage(_inventFullMessage);
            return;
        }
        foreach (Slot slot in Slots)
        {
            if (slot.CanAdd())
            {
                slot.Add(newItem);
                break;
            }
        }
    }

    public void DeleteItem(Slot slot)       //아이템을 인벤토리에 제거
    {
        Slots.Remove(slot);
        SlotFullValue--;
    }

    private void ShowUIMessage(string desc)
    {
        _messageUI.SetActive(true);
        _messageUI.GetComponentInChildren<TextMeshProUGUI>().text = desc;
        MessageShow = true;
        if(MessageShow)
            StartCoroutine(Coroutines(_messageDisapearTime));
    }

    private IEnumerator Coroutines(float Time)
    {
        yield return new WaitForSecondsRealtime(Time);
        Disable();
    }

    private void Disable()
    {
        _messageUI.SetActive(false);
        MessageShow = false;
    }

    public bool EquipItem(ItemData item)       //아이템을 장착
    {
        equipItems.Add(item);
        SetPlayerStat(item, 1);
        return true;
    }

    public bool UnEquipItem(ItemData item)      //아이템을 장착 해제
    {
        equipItems.Remove(item);
        SetPlayerStat(item, -1);
        return false;
    }

    public void SetPlayerStat(ItemData item, int v)
    {
        
    }

    public void ChangeSlot(Slot minDistanceSlot)
    {
        
    }
}
