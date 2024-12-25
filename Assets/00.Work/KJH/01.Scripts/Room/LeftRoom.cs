using System;
using UnityEngine;
using UnityEngine.UI;

public class LeftRoom : MonoBehaviour, IMap
{
    [SerializeField] private Transform _enemyPos;
    [SerializeField] private Button _leftRoomButton;

    public static Action<Transform> OnLeftMove;
    public static Action<GameObject> OnEnemy;
    public static Action OnLeftClick;

    public bool _isEntered = false;
    public bool _isExiting = false;

    private Image _image;

    public float floor;
    public GameObject _enemy;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _leftRoomButton.onClick.AddListener(OnLeftRoomClick); // ��ư Ŭ�� �̺�Ʈ �߰�
    }
    private void OnEnable()
    {
        RightRoom.OnRightClick += ExitRoom;
        CenterRoom.OnCenterClick += ExitRoom;
        RoomPanel.OnClickUpDown += ExitRoom;
    }

    private void OnDisable()
    {
        RightRoom.OnRightClick -= ExitRoom;
        CenterRoom.OnCenterClick -= ExitRoom;
        RoomPanel.OnClickUpDown -= ExitRoom;
    }
    private void Start()
    {
        StartRoom();
    }

    public void EnterRoom()
    {
        _isEntered = true;

        // �� Ȱ��ȭ
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

            // �� ��Ȱ��ȭ
            if (_enemy != null)
            {
                _enemy.SetActive(false);
            }
            var color = _image.color;
            color.a = 0.5f;
            _image.color = color;
        }
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

    public void OnLeftRoomClick()
    {
        if (!Player.IsMoveing)
        {
            // ���� ���� �ƴϸ� ����
            if (Player.CurrentRoom != 2)
            {
                OnLeftClick?.Invoke();
                OnLeftMove?.Invoke(transform);
                OnEnemy?.Invoke(_enemy);

                // ���� �� ���� �� �� ����
                Player.CurrentRoom = 2;
                EnterRoom();
            }
        }
    }

    public void SettingRoom(int a, GameObject en)
    {
        floor = a;
        _enemy = en;
        en.transform.position = _enemyPos.transform.position;
        var color = _image.color;
        color.a = 1f;
        _image.color = color;
    }
}