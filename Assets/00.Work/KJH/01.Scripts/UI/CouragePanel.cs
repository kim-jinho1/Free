using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CouragePanel : MonoBehaviour
{
    private Virtue _courage;
    
    private Label _title; 
    private Label _firstSkill; 
    private Label _secondSkill;
    private Button _upButton;

    private void Awake()
    {
        _title = GetComponent<UIDocument>().rootVisualElement.Q<Label>("VirtueName");
        _firstSkill = GetComponent<UIDocument>().rootVisualElement.Q<Label>("FirstSkill");
        _secondSkill = GetComponent<UIDocument>().rootVisualElement.Q<Label>("SecondSkill");
        _upButton = GetComponent<UIDocument>().rootVisualElement.Q<Button>("AbilityUp");
        
        _courage = new Courage();
        
    }

    private void OnEnable()
    {
        _upButton.clicked += OnClick;
    }

    private void OnClick()
    {
        _courage.AddPoint(PlayerAbility.Instance);
    }

    private void Start()
    {
        _courage.ApplyName();
        _title.text = "용기";
        _firstSkill.text = _courage.FirstStatsPointName;
        _secondSkill.text = _courage.SecondStatsPointName;
    }
}
