using System;
using UnityEngine;

public class RoomPanel : MonoBehaviour
{
    private int currentFloor;

    public static Action OnClickUpDown;

    public void OnClickDown()
    {
        if (Player.IsCenter)
        {
            currentFloor = MapManager.Instance._currentFloor;
            if (currentFloor > 1)
            {
                MapManager.Instance.ChangeFloor(false);
            }
            OnClickUpDown?.Invoke();
            PlayerUIState.UIExit();
        }
    }

    public void OnClickUp()
    {
        if (Player.IsCenter)
        {
            currentFloor = MapManager.Instance._currentFloor;
            if (currentFloor < 50)
            {
                MapManager.Instance.ChangeFloor(true);
            }
            OnClickUpDown?.Invoke();
            PlayerUIState.UIExit();
        }
    }
}