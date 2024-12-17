using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtueManager : MonoBehaviour
{
    [Header("PlayerAbility")]
    [SerializeField] private PlayerAbility _playerAbility;

    [Header("Virtue")]
    [SerializeField] private Concentration _concentration;
    [SerializeField] private Patience _patience;
    [SerializeField] private Wisdom _wisdom;
    [SerializeField] private Courage _courage;

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