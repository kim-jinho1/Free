using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    private void Start()
    {
        OnClose();
    }

    public void OnClose()
    {
        //InventoryManager.Instance._inventory.SetActive(false);
        //InventoryManager.Instance._inspector.SetActive(false);
    }

    public void OnOpen()
    {
        InventoryManager.Instance._inventory.SetActive(true);
    }
}
