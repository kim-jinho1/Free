using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat_Inven : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI 
        _attack, _hp, _hungry, _speed, _dodge, _acc, _escape, _cd, _cr;
    //[SerializeField] private          //�÷��̾� ���� SO

    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _hungrySlider;
    //[SerializeField] private //���� HP�� HUNGRY���� �������� ��
    //[SerializeField] private //�ִ� HP�� HUNGRY���� �������� ��

    public void Update()
    {
        SetStat();
        SetSlider();
    }

    private void SetSlider()
    {
        //_hpSlider.size =         //����HP / �ִ�HP
        //__hungrySliderSlider.size =         //����HUNGRY / �ִ�HUNGRY
    }

    private void SetStat()
    {
        //_attack.text = $"ATTACK : {}";
        //_hp.text = $"HP : {}";
        //_hungry.text = $"HUNGRY : {}";
        //_speed.text = $"SPEED : {}";
        //_dodge.text = $"DODGE : {}";
        //_acc.text = $"ACC : {}";
        //_escape.text = $"ESCAPE : {}";
        //_cd.text = $"C.D : {}";
        //_cr.text = $"C.R : {}";
    }


}
