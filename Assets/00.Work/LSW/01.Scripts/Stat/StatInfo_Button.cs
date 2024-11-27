using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatInfo : MonoBehaviour
{
    [SerializeField] private GameObject _statInfoUI;

    private void Start()
    {
        _statInfoUI.SetActive(false);
    }

    public void SetAble()
    {
        _statInfoUI.SetActive(true);
    }

    public void SetDisable()
    {
        _statInfoUI.SetActive(false);
    }
}
