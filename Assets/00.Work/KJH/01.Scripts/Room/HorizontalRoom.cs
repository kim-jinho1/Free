using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalRoom : MonoBehaviour
{
    public bool _isEntered = false;
    public bool _isExiting = false;
    public int _currentFloor;

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
}