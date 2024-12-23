using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : MonoSingleton<GameOverUIManager>
{
    //���� UI��ü�� �����ϴ� ��ũ��Ʈ�� �����ϸ� �� ��Ʈ�� ��ĥ ��(ȿ���� ����)

    public int _mainMenuSceneNum;

    [SerializeField] private GameObject _gameOverUIPanel, _exitButton, _restartButton;
    [SerializeField] private GameObject _alpha;

    Tweener d;

    public void Awake()        //���� ���� �� ����(��� �����ϵ���!!)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);         //����� ����(�ϴ� �� �ٽ� �ҷ�������)
    }

    public void OnExitButtonClick()
    {
        //SceneManager.LoadScene(_mainMenuSceneNum);
        Debug.Log("Exit");
    }
}
