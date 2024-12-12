using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class RSJ_MainUI : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("MainGameScene");
    }

    public void LoadBtn()
    {
        //����� ���� �̵�
    }

    public void SaveBtn()
    {
        //�����ϱ�
    }

    public void RobbyBtn()
    {
        //�κ�� ����
    }

    public void PanelOpen(GameObject pannel)
    {
        pannel.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("��");
    }

    public void PanelClose(GameObject pannel)
    {
        pannel.SetActive(false);
    }
}
