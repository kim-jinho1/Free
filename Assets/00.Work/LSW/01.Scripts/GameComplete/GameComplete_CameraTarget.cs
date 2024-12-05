using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameComplete_CameraTarget : MonoBehaviour
{
    private float _stopCameraPos_x;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameCompleteUI.instance._stopCameraPos.gameObject)
        {
            _stopCameraPos_x = collision.transform.position.x;
            GameCompleteUI.instance._isCameraStop = true;
        }
        if(collision.gameObject == GameCompleteUI.instance._portal)
        {
            GameCompleteUI.instance.ForthAction();
        }
    }

    private void Update()
    {
        if (GameCompleteUI.instance._isCameraStop)
        {
            GameCompleteUI.instance._cameraVirtual.Follow = null;
            GameCompleteUI.instance._cameraVirtual.LookAt = null;
        }
        else
        {
            GameCompleteUI.instance._cameraVirtual.Follow = GameCompleteUI.instance._player.transform;
            GameCompleteUI.instance._cameraVirtual.LookAt = GameCompleteUI.instance._player.transform;
        }
    }
}
