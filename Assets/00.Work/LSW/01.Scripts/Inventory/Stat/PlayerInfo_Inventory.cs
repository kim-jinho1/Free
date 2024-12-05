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
    //[SerializeField] private          //플레이어 스탯 SO

    [SerializeField] private Slider _hpSlider;
    [SerializeField] private Slider _hungrySlider;
    //[SerializeField] private //현재 HP와 HUNGRY값을 가져오는 것
    //[SerializeField] private //최대 HP와 HUNGRY값을 가져오는 것

    public void Update()
    {
        SetStat();
        SetSlider();
    }

    private void SetSlider()
    {
        //_hpSlider.size =         //현재HP / 최대HP
        //__hungrySliderSlider.size =         //현재HUNGRY / 최대HUNGRY
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
