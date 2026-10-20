using UnityEngine;
using Util.FSM.Interface;

namespace Game.Player.State
{
    // 작성자: 조혜찬
    // 플레이어 이동 상태
    public class PlayerMoveState : IState
    {
        private PlayerMovement _movement;

        private PlayerInput _input;

        public PlayerMoveState(PlayerMovement movement, PlayerInput input)
        {
            _movement = movement;
            _input = input;
        }

        public void OnEnter()
        {
            
        }

        public void OnExecute()
        {
            _movement.Move(_input.MoveInput);
        }

        public void OnExit()
        {
            
        }
    }
}
// 마지막 작성 일자: 2026.09.21