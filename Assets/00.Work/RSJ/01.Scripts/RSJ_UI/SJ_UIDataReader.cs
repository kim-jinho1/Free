using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SJ_UIDataReader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floor;
    [SerializeField] private TextMeshProUGUI HP;

    //private Image hpImage;

    // [SerializeField] private TextMeshProUGUI Hunger;

    private Player _player;

    [SerializeField] private AbilityData _playerData; 

    private void Awake()
    {
        _player = GetComponent<Player>();
        //hpImage.sprite = _playerData.hpImage;
    }

    private void Update()
    {
        floor.text = _player.CurrentFloor.ToString() + "F";

        HP.text = _playerData.hp.ToString();
        //Hunger.text = _playerData.
    }
}
