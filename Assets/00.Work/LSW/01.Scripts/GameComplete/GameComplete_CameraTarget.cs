using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete_CameraTarget : MonoBehaviour
{
    private float _stopCameraPos_x;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameCompleteManager.Instance._stopCameraPos.gameObject)
        {
            _stopCameraPos_x = collision.transform.position.x;
            GameCompleteManager.Instance._isCameraStop = true;
            StartCoroutine(GameCompleteManager.Instance.Coroutine(1.5f));
            GameCompleteManager.Instance.SecondAction();
        }
        if(collision.gameObject == GameCompleteManager.Instance._portal)
        {
            GameCompleteManager.Instance.ForthAction();
        }
    }

    private void Update()
    {
        if (GameCompleteManager.Instance._isCameraStop)
        {
            GameCompleteManager.Instance._cameraVirtual.Follow = null;
            GameCompleteManager.Instance._cameraVirtual.LookAt = null;
        }
        else
        {
            GameCompleteManager.Instance._cameraVirtual.Follow = GameCompleteManager.Instance._player.transform;
            GameCompleteManager.Instance._cameraVirtual.LookAt = GameCompleteManager.Instance._player.transform;
        }
    }
}
