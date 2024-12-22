using System;
using UnityEngine;
using UnityEngine.UI;

public class RightRoom : MonoBehaviour , IMap
{
    [SerializeField] private Transform _enemyPos;

    public static Action<Transform> OnRightMove;
    public static Action OnRightClick;
    public bool _isEntered = false;
    public bool _isExiting = false;
    public GameObject _enemy;

    public int floor;

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
            ExitRoom();
        }
    }

    public void EnterRoom()
    {
        Player.CurrentRoom = 1;
        _enemy.SetActive(true);
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

    private void ResetRoom()
    {
        var color = _image.color;
        color.a = 0f;
        _image.color = color;
    }



    public void OnRightRoomClick()
    {
        OnRightClick?.Invoke();
        OnRightMove?.Invoke(transform);
        EnterRoom();
    }

    void IMap.SettingRoom(int a,GameObject en)
    {
        floor = a;
        _enemy = en;
        var color = _image.color;
        color.a = 1f;
        _image.color = color;
    }
}