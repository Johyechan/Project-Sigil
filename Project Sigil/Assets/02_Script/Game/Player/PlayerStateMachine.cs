using UnityEngine;
using Util.FSM;
using Util.FSM.Interface;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어 상태 관리
    public class PlayerStateMachine
    {
        private StateMachine _machine;

        private PlayerInput _input;
        private PlayerAttack _attack;

        private IState _idleState;
        private IState _moveState;
        private IState _attackState;

        public PlayerStateMachine(IState idleState, IState moveState, IState attackState, PlayerInput input, PlayerAttack attack)
        {
            _machine = new StateMachine();

            _idleState = idleState;
            _moveState = moveState;
            _attackState = attackState;

            _input = input;
            _attack = attack;
        }

        public void Init()
        {
            _machine.Init(_idleState);
        }

        public void Execute()
        {
            // 공격 중인 상태일 때
            if(_attack.IsAttacking)
            {
                _machine.ChangeState(_attackState);
            }
            else // 공격 중이 아닐 때
            {
                if (_input.MoveInput != Vector2.zero)
                {
                    _machine.ChangeState(_moveState);
                }
                else
                {
                    _machine.ChangeState(_idleState);
                }
            }

            _machine.Execute();
        }
    }
}
// 마지막 작성 일자: 2026.09.21