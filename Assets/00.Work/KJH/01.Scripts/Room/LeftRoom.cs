using System;
using UnityEngine;
using UnityEngine.UI;

public class LeftRoom : MonoBehaviour
{
    public static Action<Transform> OnLeftMove;
    public static Action OnLeftClick;
    public bool _isEntered = false;
    public bool _isExiting = false;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        StartRoom();
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
        var color = _image.color;
        color.a = 0f;
        _image.color = color;
    }

    public void ExitRoom()
    {
        var color = _image.color;
        color.a = 0.5f;
        _image.color = color;
    }

    private void StartRoom()
    {
        var color = _image.color;
        color.a = 1f;
        _image.color = color;
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

    public void OnLeftRoomClick()
    {
        OnLeftClick?.Invoke();
        OnLeftMove?.Invoke(transform);
        EnterRoom();
    }
}