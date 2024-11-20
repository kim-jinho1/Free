using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum State { Empty, NotFull, Full }
public class Slot : MonoBehaviour
{
    [SerializeField] protected GameObject _itemMark;
    [SerializeField] protected Image _equipMark;
    public State _state;
    protected ItemData _itemData;
    protected bool equip;

    [Header("Duplicate")]
    [SerializeField] private TextMeshProUGUI _duplicateTxt;
    public int NowDulicate;

    //[Header("ItemMove")]

    [Header("Use")]
    [SerializeField] protected GameObject _inspector;

    private void Start()
    {
        _duplicateTxt.enabled = false;
    }

    private void Update()
    {
        if(_state != State.Empty)
            if(NowDulicate == _itemData.DuplicateValue)
            _state = State.Full;

        if (NowDulicate > 1)
            _duplicateTxt.enabled = true;
        else if (NowDulicate == 1)
            _duplicateTxt.enabled = false;

        //if(Input.GetKeyDown(KeyCode.Q) && gameObject.GetComponent<Button>()
        //{
            Reduce();
        //}

        //if(Input.GetMouseButtonDown(1) && InventoryManager.Instance.OnActive 
        //    && GetComponent<Button>().)
            _inspector.SetActive(true);
        else if(Input.anyKeyDown)
            _inspector.SetActive(false);
    }

    public bool CanAdd()
    {
        if (_state == State.Empty || _state == State.NotFull)
        {
            NowDulicate++;
            return true;
        }
        return false;
    }

    public void Add(ItemData newitem)
    {
        _state = State.NotFull;
        _itemData = newitem;
        Change();
        SetDuplicate(newitem);
    }

    private void SetDuplicate(ItemData newitem)
    {
        _duplicateTxt.text = NowDulicate.ToString();
    }

    private void Change()
    {
        _itemMark.GetComponent<Image>().sprite = _itemData.ItemImage;
    }

    public void Reduce()
    {
        NowDulicate--;
        SetDuplicate(_itemData);
        if(NowDulicate <= 0)
            Delete();
    }

    protected void Delete()
    {
        NowDulicate = 0;
        _equipMark.sprite = null;
        _state = State.Empty;
        _itemData = null;
        _duplicateTxt.enabled = false;
        _itemMark.GetComponent<Image>().sprite = null;
        InventoryManager.Instance.DeleteItem(this);
    }

    private IEnumerator Coroutines(float item)
    {
        yield return new WaitForSeconds(item);
    }
}
