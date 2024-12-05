using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject _itemMark;
    public SlotData _slotData;
    public event Action<Slot> OnShowInspector; 

    [Header("ItemMove")]
    [SerializeField] private GameObject _itemMove;
    public bool _isDragging, _MoveSlotEnter;

    [Header("Use")]
    public bool _isMousePointIn;
    public string EquipTxt = "EQUIP";
    public string UnEquipTxt = "UNEQUIP";
    public string UseTxt = "USE";
    public string HealTxt = "HEAL";
    public Image _equipBorder;
    public GameObject _equipMark;

    private void Start()
    {
        _equipMark.SetActive(false);
    }

    private void Update()
    {
        if (_isMousePointIn && Input.GetMouseButtonDown(1) && _slotData.itemData != null)
        {
            InventoryManager.Instance._inspector.SetActive(true);
            OnShowInspector?.Invoke(this);
        }

        if (_slotData.equip)
        {
            _equipBorder.color = Color.red;
            _equipMark.SetActive(true);

        }
        else
        {
            _equipBorder.color = Color.black;
            _equipMark.SetActive(false);
        }
    }

    public void AddItem(ItemData newitem)
    {
        _slotData.state = State.Full;
        _slotData.itemData = newitem;
        _slotData.itemData.ItemImage = newitem.ItemImage;
        ChangeImage(_slotData.itemData.ItemImage);
    }

    public void ChangeImage(Sprite sprite)
    {
        _itemMark.GetComponent<Image>().sprite = sprite;
    }

    public void Delete()
    {
        if (_slotData.equip)
        {
            InventoryManager.Instance.UnEquipItem(this);
        }
        _equipMark.SetActive(false);
        _slotData.state = State.Empty;
        _slotData.itemData = null;
        _itemMark.GetComponent<Image>().sprite = null;
        InventoryManager.Instance.DeleteItem(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isMousePointIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isMousePointIn = false;
    }

    public void ResetData()
    {
        if (_slotData.equip)
        {
            InventoryManager.Instance.UnEquipItem(this);
        }

        _slotData.itemData = null;
        _slotData.itemType = itemType.Equip;
        _slotData.state = State.Empty;

        _slotData.equip = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0) && _slotData.itemData != null)
        {
            _isDragging = true;
            InventoryManager.Instance._slotChangeObject = Instantiate(InventoryManager.Instance._slotMovePrefabs, InventoryManager.Instance.GetMousePos(), Quaternion.identity);
            InventoryManager.Instance._slotChangeObject.transform.SetParent(InventoryManager.Instance._inventory.transform);
            InventoryManager.Instance._inspector.SetActive(false);
            InventoryManager.Instance._slotChangeObject.SetActive(true);
            InventoryManager.Instance._slotChangeObject.GetComponent<Slot_Move>().SetImage(_slotData.itemData.ItemImage);
            ChangeImage(null);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isDragging)
        {
            InventoryManager.Instance._slotChangeObject.GetComponent<Slot_Move>().Check(this);
            _isDragging = false;
        }
    }
}
