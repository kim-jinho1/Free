using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoSingleton<GameOverUIManager>
{
    //만약 UI전체를 관리하는 스크립트가 존재하면 그 립트와 합칠 것(효율을 위해)

    public int _mainMenuSceneNum;

    [SerializeField] private GameObject GameOverUIPanel;
    [SerializeField] private GameObject _alpha;

    private void Start()
    {
        GameOverUIPanel.SetActive(false);
    }

    public void ShowGameOverUI()        //게임 오버 시 실행(어디서 실행하도록!!)
    {
        GameOverUIPanel.SetActive(true);
        _alpha.GetComponent<Image>().DOFade(0.55f, 2);
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);         //재시작 관련(일단 씬 다시 불러오기함)
    }

    public void OnExitButtonClick()
    {
        //SceneManager.LoadScene(_mainMenuSceneNum);
        Debug.Log("Exit");
    }
}
