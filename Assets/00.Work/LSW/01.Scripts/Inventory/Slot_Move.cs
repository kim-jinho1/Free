using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Move : MonoBehaviour
{
    private Slot _changeTargetSlot;
    private Slot _originSlot;
    private void Update()
    {
        gameObject.transform.localPosition = InventoryManager.Instance.GetMousePos();
    }

    public void SetImage(Sprite sprite)
    {
        GetComponent<Image>().sprite = sprite;
    }

    public void Check(Slot origin)
    {
        _originSlot = origin;
        _changeTargetSlot = GetCloseSlot();
        if (_changeTargetSlot != null)
            ChangeSlot();
        else if (_changeTargetSlot == null)
            CancelItemMove();
    }

    public void ChangeSlot()
    {
        if (_changeTargetSlot._slotData.state == State.Empty)
        {
            _changeTargetSlot.AddItem(_originSlot._slotData.itemData);
            _originSlot.ResetData();
            Destroy();
        }
        else
            ChangeSlotEach();
    }

    public void ChangeSlotEach()
    {
        ItemData tempSlotData = _changeTargetSlot._slotData.itemData;
        _changeTargetSlot.AddItem(_originSlot._slotData.itemData);
        //_originSlot._slotData.itemData = tempSlotData;
        _originSlot.AddItem(tempSlotData);
        Destroy();
    }

    public void CancelItemMove()
    {
        _originSlot.ChangeImage(_originSlot._slotData.itemData.ItemImage);
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public Slot GetCloseSlot()
    {
        if (InventoryManager.Instance._eachChangeSlot.Count > 1)
        {
            Slot closestSlot = InventoryManager.Instance._eachChangeSlot[0];
            foreach (var item in InventoryManager.Instance._eachChangeSlot)
            {
                if (Mathf.Abs(Vector2.Distance(gameObject.transform.position, closestSlot.transform.position))
                    >= Mathf.Abs(Vector2.Distance(gameObject.transform.position, item.gameObject.transform.position)))
                {
                    closestSlot = item;
                }
            }
            return closestSlot;
        }
        else if(InventoryManager.Instance._eachChangeSlot.Count == 1)
        {
            return InventoryManager.Instance._eachChangeSlot[0];
        }
        else
        {
            return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            InventoryManager.Instance._eachChangeSlot.Add(collision.gameObject.GetComponent<Slot>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slot"))
        {
            InventoryManager.Instance._eachChangeSlot.Remove(collision.gameObject.GetComponent<Slot>());
        }
    }
}
