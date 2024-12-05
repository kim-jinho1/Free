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

    private void Update()
    {
        floor.text = _player.CurrentFloor.ToString() + "F";

        HP.text = _player.AbilityData.currentHp.ToString("F1") + " / " + _player.AbilityData.maxHp.ToString("F1");
        Hunger.text = _player.AbilityData.currentHungry.ToString("F1") + " / " + _player.AbilityData.maxHungry.ToString("F1");
    }
}
