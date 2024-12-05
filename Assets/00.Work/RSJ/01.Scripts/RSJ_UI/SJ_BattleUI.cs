
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
        //List 받아와서 공격 퍼센트에 따라 데미지 넣기 ㅇㅇ
        int per = Random.Range(0,101);
        if(per >= 50)
        {
            Debug.Log("공격");
        }
        else
        {
            Debug.Log("개모태");
        }
        pannel.SetActive(false);
    }
}
