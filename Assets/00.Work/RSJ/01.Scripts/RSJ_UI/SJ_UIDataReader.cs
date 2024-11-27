using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SJ_UIDataReader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floor;
    [SerializeField] private TextMeshProUGUI HP;
    [SerializeField] private TextMeshProUGUI Hunger;

    [SerializeField] private Player _player;

    //[SerializeField] private AbilityData _playerData; 

    private void Update()
    {
        floor.text = _player.CurrentFloor.ToString() + "F";

        HP.text = _player.AbilityData.CurrentHp.ToString() + " / " + _player.AbilityData.maxHp.ToString();
        Hunger.text = _player.AbilityData.CurrnetHungry.ToString() + " / " + _player.AbilityData.MaxHungry.ToString();
    }
}
