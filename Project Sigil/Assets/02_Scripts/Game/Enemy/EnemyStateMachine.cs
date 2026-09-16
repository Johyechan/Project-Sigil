using Util.FSM;
using Util.FSM.Interface;

namespace Game.Enemy
{
    // 작성자: 조혜찬
    // 적 상태 관리 머신
    public class EnemyStateMachine
    {
        private StateMachine _stateMachine; // 상태 관리 머신

        private IState _idleState; // 기본 상태
        private IState _moveState; // 이동 상태

        private EnemyMovement _movement; // 적 이동 클래스

        public EnemyStateMachine(IState idleState, IState moveState, EnemyMovement movement)
        {
            _stateMachine = new StateMachine();

            _idleState = idleState;
            _moveState = moveState;
            _movement = movement;
        }

        public void Init()
        {
            _stateMachine.Init(_idleState);
        }

        public void Execute()
        {
            // 멈춰야 한다면
            if(_movement.ShouldStop())
            {
                // 기본 상태로 변경
                _stateMachine.ChangeState(_idleState);
            }
            else // 멈추지 않아도 된다면
            {
                _stateMachine.ChangeState(_moveState);
            }

            _stateMachine.Execute(); // 현재 상태에서 매 프레임 실행되어야 하는 코드를 가지는 함수
        }
    }
}
// 마지막 작성 일자: 2026.09.16