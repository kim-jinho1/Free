using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtueManager : MonoBehaviour
{
    [Header("PlayerAbility")]
    [SerializeField] private PlayerAbility _playerAbility;

     private Concentration _concentration;
     private Patience _patience;
     private Wisdom _wisdom;
     private Courage _courage;

    private void Awake()
    {
        _concentration = new Concentration();
        _patience = new Patience();
        _wisdom = new Wisdom();
        _courage = new Courage();
    }

    public void OnUpConcentration()
    {
        _concentration.AddPoint(_playerAbility);
    }
    public void OnUpPatience()
    {
        _patience.AddPoint(_playerAbility);
    }
    public void OnUpWisdom()
    {
        _wisdom.AddPoint(_playerAbility);
    }
    public void OnUpCourage()
    {
        _courage.AddPoint(_playerAbility);
    }
}