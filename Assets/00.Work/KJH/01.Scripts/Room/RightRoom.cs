using System;
using UnityEngine;
using UnityEngine.UI;

public class RightRoom : MonoBehaviour, IMap
{
    [SerializeField] private Transform _enemyPos;
    [SerializeField] private Button _rightRoomButton;

    public static Action<GameObject> OnEnemy;
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
        _rightRoomButton.onClick.AddListener(OnRightRoomClick); // 버튼 클릭 이벤트 추가
    }

    private void OnEnable()
    {
        LeftRoom.OnLeftClick += ExitRoom;
        CenterRoom.OnCenterClick += ExitRoom;
        RoomPanel.OnClickUpDown += ExitRoom;
    }

    private void OnDisable()
    {
        LeftRoom.OnLeftClick -= ExitRoom;
        CenterRoom.OnCenterClick -= ExitRoom;
        RoomPanel.OnClickUpDown -= ExitRoom;
    }

    public void EnterRoom()
    {
        _isEntered = true;

        // 적 활성화
        if (_enemy != null)
        {
            _enemy.SetActive(true);
        }

        var color = _image.color;
        color.a = 0f;
        _image.color = color;
    }

    public void ExitRoom()
    {
        if (_isEntered && _isExiting)
        {
            _isExiting = true;

            // 적 비활성화
            if (_enemy != null)
            {
                _enemy.SetActive(false);
            }
            var color = _image.color;
            color.a = 0.5f;
            _image.color = color;
        }
    }

    private void ResetRoom()
    {
        var color = _image.color;
        color.a = 0f;
        _image.color = color;
    }

    public void OnRightRoomClick()
    {
        if (!Player.IsMoveing)
        {
            if (Player.CurrentRoom != 1)
            {
                OnRightClick?.Invoke();
                OnRightMove?.Invoke(transform);
                OnEnemy?.Invoke(_enemy);

                // 현재 방 설정 및 방 입장
                Player.CurrentRoom = 1;
                EnterRoom();
            }
        }
    }

    public void SettingRoom(int a, GameObject en)
    {
        floor = a;
        _enemy = en;
        en.transform.GetChild(0).GetChild(0).Rotate(0, 180, 0);
        en.transform.position = _enemyPos.transform.position;
        var color = _image.color;
        color.a = 1f;
        _image.color = color;
    }
}