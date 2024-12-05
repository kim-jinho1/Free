using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test_GameOverButton : MonoBehaviour
{
    public void Test()
    {
        GameOverUIManager.Instance.ShowGameOverUI();
    }
}
