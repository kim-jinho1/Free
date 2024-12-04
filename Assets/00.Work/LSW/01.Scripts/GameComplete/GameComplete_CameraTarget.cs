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
            GameCompleteUI.instance._isStop = true;
        }
    }

    private void Update()
    {
        if (GameCompleteUI.instance._isStop)
            transform.position = new Vector2(_stopCameraPos_x, transform.position.y);
        else
            transform.position = GameCompleteUI.instance._player.transform.position;
    }
}
