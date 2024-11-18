using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RSJ_MainUI : MonoBehaviour
{
    [SerializeField] private GameObject pannel;

    public void StartBtn()
    {
        //게임씬 이동
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

    public void SettingBtn()
    {
        pannel.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("끗");
    }

    public void PannelClose()
    {
        pannel.SetActive(false);
    }
}
