using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompleteUI : MonoBehaviour
{
    public static GameCompleteUI instance;

    [SerializeField] private CinemachineConfiner2D _mainCameraConfiner;
    public GameObject _player;
    [SerializeField] private Transform[] _movePoints;
    public GameObject _stopCameraPos;

    public bool _isStop;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FirstAction();
    }

    private void FirstAction()
    {
        _player.transform.DOMoveX(_movePoints[0].position.x, 2f).OnComplete(() => Invoke("SecondAction", 1.5f));
    }

    private void SecondAction()
    {
        _isStop = false;
        Invoke("ThirdAction", 1.5f);
    }

    private void ThirdAction()
    {
        _player.transform.DOMoveY(_movePoints[1].position.y, 1f);
        _player.transform.DOMoveX(_movePoints[1].position.x, 1f);
        ForthAction();
    }

    private void ForthAction()
    {
        
    }
}
