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

    public void SettingBtn()
    {
        pannel.SetActive(true);
    }

    public void ExitBtn()
    {
        Application.Quit();
        Debug.Log("��");
    }

    public void PannelClose()
    {
        pannel.SetActive(false);
    }
}
