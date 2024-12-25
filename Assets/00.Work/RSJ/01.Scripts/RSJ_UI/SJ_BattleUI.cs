using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SJ_BattleUI : MonoBehaviour
{
    public EnemySO enemySO;
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
        pannel.transform.DOMoveX(1200,1f);
    }
}
