using System;
using UnityEngine;
using UnityEngine.UI;

public class HorizontalRoom : MonoBehaviour
{
    public static Action<Transform> OnMove;
    public static Action OnClick;
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
        _isEntered = true;
    }

    public void ExitRoom()
    {
        _isExiting = true;
    }

    private void StartRoom()
    {
        Debug.Log("StartRoom");
        var color = _image.color;
        color.a = 0.95f;
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

    public void OnHorizontalRoomClick()
    {
        Debug.Log("11s");
        OnClick?.Invoke();
        OnMove?.Invoke(transform);
        EnterRoom();
    }
}