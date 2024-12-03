using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoSingleton<GameOverUIManager>
{
    //���� UI��ü�� �����ϴ� ��ũ��Ʈ�� �����ϸ� �� ��Ʈ�� ��ĥ ��(ȿ���� ����)

    public int _mainMenuSceneNum;

    [SerializeField] private GameObject GameOverUIPanel;
    [SerializeField] private GameObject _alpha;

    private void Start()
    {
        GameOverUIPanel.SetActive(false);
    }

    public void ShowGameOverUI()        //���� ���� �� ����(��� �����ϵ���!!)
    {
        GameOverUIPanel.SetActive(true);
        _alpha.GetComponent<Image>().DOFade(0.55f, 2);
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);         //����� ����(�ϴ� �� �ٽ� �ҷ�������)
    }

    public void OnExitButtonClick()
    {
        //SceneManager.LoadScene(_mainMenuSceneNum);
        Debug.Log("Exit");
    }
}
