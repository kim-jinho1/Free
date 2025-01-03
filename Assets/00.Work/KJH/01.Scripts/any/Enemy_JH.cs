using System;
using UnityEngine;

public class Enemy_JH : MonoBehaviour
{
    public GameObject enemy;
    public static Action<GameObject> OnClick;

    public void OnEnemyClick()
    {
        MapManager.Instance._battlePanel.SetActive(true);
        OnClick?.Invoke(enemy);
    }
}