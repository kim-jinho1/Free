using System;
using UnityEngine;

public class VerticalRoom : MonoBehaviour
{ 
    private GameObject roomPanel;
    public static Action<Transform> OnMove;
    public static Action OnClick;

    public bool _isEntered = false;
    public bool _isExiting = false;

    private void Awake()
    {
        roomPanel = MapManager.Instance.mapPanel;
    }

    private void Update()
    {
        if (_isEntered && !_isExiting)
        {
            ResetRoom();
        }
        else if (_isEntered && _isExiting)
        {
            SettingRoom();
        }
    }

    public void EnterRoom()
    {
        _isEntered = true;
    }

    public void ExitRoom()
    {
        _isExiting = true;
    }

    private void ResetRoom()
    {
        
    }

    private void SettingRoom()
    {
        
    }

    public void OnVerticalRoomClick()
    {
        OnMove?.Invoke(transform);
        OnClick?.Invoke();
        roomPanel.SetActive(true);
        EnterRoom();
    }
}
