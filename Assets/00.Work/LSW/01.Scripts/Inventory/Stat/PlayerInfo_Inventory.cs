using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat_Inven : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI 
        _attack, _hp, _hungry, _speed, _dodge, _acc, _escape, _cd, _cr;
    [SerializeField] private AbilityData _playerStat;   //플레이어 스탯 SO

    [SerializeField] private Scrollbar _hpSlider;
    [SerializeField] private Scrollbar _hungrySlider;
    //[SerializeField] private //현재 HP와 HUNGRY값을 가져오는 것
    //[SerializeField] private //최대 HP와 HUNGRY값을 가져오는 것

    public void Update()
    {
        SetStat();
        SetSlider();
    }

    private void SetSlider()
    {
        _hpSlider.size = _playerStat.currentHp / _playerStat.maxHp;       //현재HP / 최대HP
        _hungrySlider.size = _playerStat.currentHungry / _playerStat.maxHungry;  //현재HUNGRY / 최대HUNGRY
    }

    private void SetStat()
    {
        _attack.text = $"ATTACK : {_playerStat.attack}";
        _hp.text = $"HP : {_playerStat.currentHp}";
        _hungry.text = $"HUNGRY : {_playerStat.currentHungry}";
        _speed.text = $"SPEED : {_playerStat.speed}";
        _dodge.text = $"DODGE : {_playerStat.dodge}";
        _acc.text = $"ACC : {_playerStat.accuracy}";
        _escape.text = $"ESCAPE : {_playerStat.escape}";
        _cd.text = $"C.D : {_playerStat.criticalAttack}";
        _cr.text = $"C.R : {_playerStat.critical}";
    }


}
