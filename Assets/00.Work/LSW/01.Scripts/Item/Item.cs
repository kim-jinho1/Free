using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    public ItemData Data;

    private void Update()
    {
        //InventoryManager.Instance.SetItem(Data);
    }
}
