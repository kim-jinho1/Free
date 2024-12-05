using System;
using UnityEngine;

public class RoomPanel : MonoBehaviour
{
    private GameObject roomPanel;
    private int currentFloor = 1;

    private void Awake()
    {
        roomPanel = MapManager.Instance.mapPanel;
    }

    public void OnClickDown()
    {
        currentFloor = MapManager.Instance._currentFloor;

        if (currentFloor > 1)
        {
            MapManager.Instance.ChangeFloor(false);
        }
        roomPanel.SetActive(false);
    }
    
    public void OnClickUp()
    {
        currentFloor = MapManager.Instance._currentFloor;

        if (currentFloor <= 50)
        {
            MapManager.Instance.ChangeFloor(true);
        }
        roomPanel.SetActive(false);
    }
}
