using System;
using UnityEngine;

public class RoomPanel : MonoBehaviour
{
    
    [SerializeField] private Player _player;

    public static Action OnClick;

    private int currentFloor;
    
    public void OnClickDown()
    {
        OnClick?.Invoke();
        currentFloor = MapManager.Instance._currentFloor;
        if (currentFloor >= 1) 
        {
            MapManager.Instance.ChangeFloor(false);
            gameObject.SetActive(false);
        }
    }
    
    public void OnClickUp()
    {
        OnClick?.Invoke();
        currentFloor = MapManager.Instance._currentFloor;
        if (currentFloor < 50) 
        {
            MapManager.Instance.ChangeFloor(true);
            gameObject.SetActive(false);
        }
    }
}
