using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalRoom : MonoBehaviour
{
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
}
