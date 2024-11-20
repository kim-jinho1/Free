using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Test { Get, Delete }
public class Test_GetItem : MonoBehaviour
{
    [SerializeField] private ItemData itemData;
    private List<Slot> r = new List<Slot>();
    public Test t;

    public void OnClick()
    {
        if (t == Test.Get)
        {
            InventoryManager.Instance.AddItem(itemData);
        }
        else if (t == Test.Delete)
        {
            List<Slot> slot = new List<Slot>();
            slot = InventoryManager.Instance.Slots;
            for (int i = 0; i < slot.Count; i++)
            {
                if (slot[i].GetComponent<Slot>()._state != State.Empty)
                {
                    r.Add(slot[i]);
                }
            }
            if (r.Count > 0)
                r[Random.Range(0, r.Count)].Reduce();
        }
    }
}
