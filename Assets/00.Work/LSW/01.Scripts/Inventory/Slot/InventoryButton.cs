using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject _Inven;


    private void Start()
    {
        OnClose();
    }

    public void OnClose()
    {
        _Inven.SetActive(false);
        _Inven.SetActive(false);
    }

    public void OnOpen()
    {
        InventoryManager.Instance._inventory.SetActive(true);
    }
}
