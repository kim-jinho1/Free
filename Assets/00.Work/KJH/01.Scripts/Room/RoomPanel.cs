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
        if (currentFloor > 1) 
        {
            MapManager.Instance.MoveToFloor(currentFloor--);
        }
        roomPanel.SetActive(false);
    }
    
    public void OnClickUp()
    {
        if (currentFloor <= 50) 
        {
            MapManager.Instance.MoveToFloor(currentFloor++);
        }
        roomPanel.SetActive(false);
    }
}
