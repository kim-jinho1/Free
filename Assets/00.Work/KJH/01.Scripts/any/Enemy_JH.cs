using System;
using UnityEngine;

public class Enemy_JH : MonoBehaviour
{
    public GameObject enemy;
    public static Action<GameObject> OnClick;

    public void OnBtnClick()
    {
        OnClick?.Invoke(enemy);
    }
}
