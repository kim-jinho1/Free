using System;
using UnityEngine;
using UnityEngine.UI;

public class CenterRoom : MonoBehaviour, IMap
{
    [SerializeField] private Transform _enemyPos;
    [SerializeField] private Button _centerRoomButton;

    public static Action<GameObject> OnEnemy;
    public static Action<Transform> OnCenterMove;
    public static Action OnCenterClick;

    public bool _isEntered = true;
    public bool _isExiting = false;

    private Image _image;

    public int _floor;
    public GameObject _enemy;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _centerRoomButton.onClick.AddListener(OnCenterRoomClick); // ��ư Ŭ�� �̺�Ʈ �߰�
    }
    private void OnEnable()
    {
        RightRoom.OnRightClick += ExitRoom;
        LeftRoom.OnLeftClick += ExitRoom;
        RoomPanel.OnClickUpDown += ExitRoom;
        EnterRoom();
    }

    private void OnDisable()
    {
        RightRoom.OnRightClick -= ExitRoom;
        LeftRoom.OnLeftClick -= ExitRoom;
        RoomPanel.OnClickUpDown -= ExitRoom;
        ExitRoom();
    }

    public void EnterRoom()
    {
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

    private void ResetRoom()
    {
        var color = _image.color;
        color.a = 0f;
        _image.color = color;
    }

    public void OnCenterRoomClick()
    {
        if (!Player.IsMoveing)
        {

            // ���� ���� �ƴϸ� ����
            if (Player.CurrentRoom != 0)
            {
                OnCenterClick?.Invoke();
                OnCenterMove?.Invoke(transform);
                OnEnemy?.Invoke(_enemy);

                // ���� �� ���� �� �� ����
                Player.CurrentRoom = 0;
                EnterRoom();
            }
        }
    }

    void IMap.SettingRoom(int floor, GameObject en)
    {
        _floor = floor;
        _enemy = en;
        en.transform.GetChild(0).GetChild(0).Rotate(0, 180, 0);
        en.transform.position = _enemyPos.transform.position;
        var color = _image.color;
        color.a = 0.4f;
        _image.color = color;
    }
}
