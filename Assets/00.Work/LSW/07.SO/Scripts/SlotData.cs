using UnityEngine;

public enum State { Empty, Full }
[CreateAssetMenu(menuName = "Inventory/SlotData")]
public class SlotData : ScriptableObject
{
    public ItemData itemData = null;

    public itemType itemType = itemType.Equip;
    public State state = State.Empty;

    public bool equip = false;
}
