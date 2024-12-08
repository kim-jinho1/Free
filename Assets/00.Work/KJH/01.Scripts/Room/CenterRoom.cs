using System;
using UnityEngine;
using UnityEngine.UI;

public class CenterRoom : MonoBehaviour
{
    public static Action<Transform> OnCenterMove;
    public static Action OnCenterClick;

    public bool _isEntered = true;
    public bool _isExiting = false;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
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
        var color = _image.color;
        color.a = 0f;
        _image.color = color;
    }

    private void SettingRoom()
    {
        var color = _image.color;
        color.a = 0.4f;
        _image.color = color;
    }

    public void OnCenterRoomClick()
    {
        OnCenterClick?.Invoke();
        OnCenterMove?.Invoke(transform);
        EnterRoom();
    }
}