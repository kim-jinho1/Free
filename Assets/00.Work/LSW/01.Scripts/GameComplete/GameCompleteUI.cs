using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleteUI : MonoBehaviour
{
    public static GameCompleteUI instance;

    public CinemachineVirtualCamera _cameraVirtual;
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private GameObject _teleportPoint;
    [SerializeField] private Image _darkPanel;

    public int _mainMenuSceneNum;
    public GameObject _player;
    public GameObject _stopCameraPos, _portal;

    public bool _isCameraStop;

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
        _player.transform.DOMoveX(_movePoints[0].position.x, 3f).OnComplete(() => Invoke("SecondAction", 1.5f));
    }

    private void SecondAction()
    {
        _isCameraStop = false;
        Invoke("ThirdAction", 1.5f);
    }

    private void ThirdAction()
    {
        _player.transform.DOMoveY(_movePoints[1].position.y, 1f);
        _player.transform.DOMoveX(_movePoints[1].position.x, 1f);
    }

    public void ForthAction()
    {
        _darkPanel.DOFade(1f, 2f).OnComplete(() => 
        {
            ChangeScene();
        });
    }

    private void ChangeScene()
    {
        _player.transform.position = _teleportPoint.transform.position;
        _player.GetComponent<Rigidbody2D>().gravityScale = 1f;
        FiveAcion();
    }

    private void FiveAcion()
    {
        _darkPanel.DOColor(Color.black, 1.5f).OnComplete(() =>
        {
            _darkPanel.DOFade(0f, 1f);
            Invoke("SixAction", 1.5f);
        });
    }

    private void SixAction()
    {
        _player.GetComponent<SpriteRenderer>().flipX = true;
        StartCoroutine(Coroutine(2f));
        SevenAction();
    }

    private void SevenAction()
    {
        _player.GetComponent<SpriteRenderer>().flipX = false;
        _player.transform.DOMoveX(_movePoints[2].position.x, 5f);
        _isCameraStop = true;
        GameEnded();
        Invoke("Quit", 2f);
    }

    private void Quit()
    {
        SceneManager.LoadScene(_mainMenuSceneNum);
    }

    private void GameEnded()
    {
        _darkPanel.DOFade(1f, 1.5f);
    }

    private IEnumerator Coroutine(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
