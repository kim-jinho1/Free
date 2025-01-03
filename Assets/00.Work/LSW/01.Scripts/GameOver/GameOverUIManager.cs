using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoSingleton<GameOverUIManager>
{
    //만약 UI전체를 관리하는 스크립트가 존재하면 그 립트와 합칠 것(효율을 위해)

    public int _mainMenuSceneNum;

    [SerializeField] private GameObject _gameOverUIPanel, _exitButton, _restartButton;
    [SerializeField] private GameObject _alpha;

    Tweener d;

    public void Awake()        //게임 오버 시 실행(어디서 실행하도록!!)
    {
        _gameOverUIPanel.SetActive(true);
        _exitButton.SetActive(false);
        _restartButton.SetActive(false);
        d = _alpha.GetComponent<Image>().DOFade(0.5f, 3).OnComplete(() =>
        {
            Active();
        });
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            d.Kill();
            Color a = _alpha.GetComponent<Image>().color;
            a.a = 0.5f;
            _alpha.GetComponent<Image>().color = a;
            Active();
        }
    }

    public void Active()
    {
        _exitButton.SetActive(true);
        _restartButton.SetActive(true);
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
