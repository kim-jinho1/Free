using System;
using UnityEngine;

public class HorizontalRoom : MonoBehaviour
{
    public static Action<Transform> OnMove;
    public static Action OnClick;
    public bool _isEntered = false;
    public bool _isExiting = false;

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

    public void OnHorizontalRoomClick()
    {
        Debug.Log("11s");
        OnClick?.Invoke();
        OnMove?.Invoke(transform);
    }
}