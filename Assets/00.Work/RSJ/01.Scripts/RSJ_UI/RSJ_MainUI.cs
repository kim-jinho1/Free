using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RSJ_MainUI : MonoBehaviour
{
    [SerializeField] private GameObject FadePannel;

    public void StartBtn()
    {
        StartCoroutine(Fading());
        Invoke("StartGame", 1f);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void LoadBtn()
    {
        //저장된 구간 이동
    }

    public void SaveBtn()
    {
        //저장하기
    }

    public void RobbyBtn()
    {
        //로비로 복귀
    }

    public void PanelOpen(GameObject pannel)
    {
        pannel.transform.DOMove(new Vector3(960f,540f,0), 1).SetEase(Ease.OutBack);
    }

    public void ExitBtn()
    {
        StartCoroutine(Fading());
        Invoke("OutGame", 1f);
    }

    public void OutGame()
    {
        Application.Quit();
        Debug.Log("나가기");
    }

    public void PanelClose(GameObject pannel)
    {
        pannel.transform.DOMove(new Vector3(960f, -1200f, 0), 1).SetEase(Ease.OutBack);
    }

    private IEnumerator Fading()
    {
        FadePannel.SetActive(true);
        FadePannel.GetComponent<Image>().DOFade(100, 120F);
        yield return new WaitForSeconds(1f);
    }
}
