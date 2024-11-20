using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot_ItemMove : Slot, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform canvasRect;

    public float holdTime = 2f;
    public float changeMinDistance = 0.5f;
    private Slot minDistanceSlot;

    private bool _mouseHolding;

    private Vector3 mousePos;
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_mouseHolding)
        {
            InventoryManager.Instance._movingItem.transform.position = mousePos;
            InventoryManager.Instance._movingItem.GetComponent<Image>().sprite = _itemData.ItemImage;
            _itemMark.GetComponent<Image>().sprite = null;
            InventoryManager.Instance._movingItem.SetActive(true);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_state == State.Full)
        {
            if (_mouseHolding)
            {
                DragItem();
                return;
            }
        }
    }
    private void DragItem()
    {
        Vector3 mousePos = Input.mousePosition;
        InventoryManager.Instance._movingItem.transform.position = mousePos;
        InventoryManager.Instance._movingItem.GetComponent<Image>().sprite = _itemData.ItemImage;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_mouseHolding)
        {
            minDistanceSlot = this;
            float minDis = 0f;
            foreach (Slot slot in InventoryManager.Instance.Slots)
            {
                float dis = Vector2.Distance(slot.gameObject.transform.position, mousePos);
                if (dis >= changeMinDistance)
                {
                    if (minDis > dis)
                    {
                        minDis = dis;
                        minDistanceSlot = slot;
                    }
                }
            }

            if (minDistanceSlot != this)
                InventoryManager.Instance.ChangeSlot(minDistanceSlot);
            else
                ReturningSlot();
            _mouseHolding = false;
        }
    }

    private void ReturningSlot()
    {
        InventoryManager.Instance._movingItem.SetActive(false);
        Add(_itemData);
    }

}
