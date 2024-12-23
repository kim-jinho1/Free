using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolHash) : base(player, stateMachine, animBoolHash)
    {

    }

    public override void Enter()
    {
        base.Enter();
        RightRoom.OnRightClick += CheckRoom;
        LeftRoom.OnLeftClick += CheckRoom;
    }

    private void CheckRoom()
    {
        StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
        Player.IsCenter = false;
    }

    private void CheckCenterRoom()
    {
        if (Player.IsCenter)
            StateMachine.ChangeState(PlayerStateEnum.UI);
        else if (!Player.IsCenter)
        {
            StateMachine.ChangeState(PlayerStateEnum.HorizontalMove);
            Player.CanMove = false;
            Player.IsCenter = true;
        }
    }


    public override void Update()
    {
        if (Player.CanMove)
        {
            EnemyClick();
        }
    }

    private void EnemyClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PointerEventData pointerData = new PointerEventData(Player.eventSystem)
            {
                position = Input.mousePosition // 마우스 위치
            };

            List<RaycastResult> results = new List<RaycastResult>();
            Player.graphicRaycaster.Raycast(pointerData, results);

            foreach (RaycastResult result in results)
            {
                Debug.Log($"Clicked on: {result.gameObject.name}");
                if(result.gameObject.TryGetComponent(out Enemy_JH enemy))
                {
                    enemy.OnEnemyClick();
                }
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
        RightRoom.OnRightClick -= CheckRoom;
        LeftRoom.OnLeftClick -= CheckRoom;
        CenterRoom.OnCenterClick -= CheckCenterRoom;
    }
}