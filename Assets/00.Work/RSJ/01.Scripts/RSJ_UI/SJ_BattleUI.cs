
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SJ_BattleUI : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> percentList;
    [SerializeField] private List<TextMeshProUGUI> damageList;
    [SerializeField] private GameObject pannel;

    public void Awake()
    {
        for(int i = 0; i < 3; i++)
        {
            percentList[i].text = "50%";
            damageList[i].text = "3 ~ 5";
        }
    }

    public void Attack(int ListNum)
    {
        //List �޾ƿͼ� ���� �ۼ�Ʈ�� ���� ������ �ֱ� ����
        int per = Random.Range(0,101);
        if(per >= 50)
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("������");
        }
        pannel.SetActive(false);
    }
}
