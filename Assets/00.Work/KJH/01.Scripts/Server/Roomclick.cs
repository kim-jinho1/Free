using System;
using UnityEngine;

public class Roomclick : MonoBehaviour
{
    public static Action OnBtnClick;

    

    public void OnClick()
    {
        OnBtnClick?.Invoke();
    }
}