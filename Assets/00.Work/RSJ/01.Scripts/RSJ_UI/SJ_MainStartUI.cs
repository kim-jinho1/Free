using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class SJ_MainStartUI : MonoBehaviour
{
    [SerializeField] private GameObject BtnGroup;
    [SerializeField] private GameObject Title;

    void Start()
    {
        BtnGroup.transform.DOMove(new Vector3(1003,540), 1.5f).SetEase(Ease.OutBack);
        Title.transform.DOMove(new Vector3(600,893), 1.2f).SetEase(Ease.OutBack);
    }
}
