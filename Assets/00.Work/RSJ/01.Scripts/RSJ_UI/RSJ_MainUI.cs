using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RSJ_MainUI : MonoBehaviour
{
    public void StartBtn()
    {
        //���Ӿ� �̵�
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

    public void PannelOpen(GameObject pannel)
    {
        pannel.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("��");
    }

    public void PannelClose(GameObject pannel)
    {
        pannel.SetActive(false);
    }
}
