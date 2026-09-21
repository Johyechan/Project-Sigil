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
        private IState _attackState; // 공격 상태
        private IState _hitState; // 피격 상태
        private IState _dieState; // 사망 상태

        private EnemyMovement _movement; // 적 이동 클래스
        
        private EnemyHealth _health; // 적 체력 클래스

        public EnemyStateMachine(IState idleState, IState moveState, IState attackState, IState hitState, IState dieState, 
            EnemyMovement movement, EnemyHealth health)
        {
            _stateMachine = new StateMachine();

            _idleState = idleState;
            _moveState = moveState;
            _attackState = attackState;
            _hitState = hitState;
            _dieState = dieState;

            _movement = movement;
            _health = health;
        }

        public void Init()
        {
            _stateMachine.Init(_idleState);
        }

        public void Execute()
        {
            // 현재 상태가 사망 상태라면
            if(_stateMachine.CurrentState == _dieState)
            {
                return;
            }
            else // 사망 상태가 아니라면
            {
                if(_health.IsDie()) // 체력이 사망 상태라고 판단했다면
                {
                    _stateMachine.ChangeState(_dieState); // 현재 상태를 사망 상태로 전환
                }
            }

            // 멈춰야 한다면
            if (_movement.ShouldAttack())
            {
                // 기본 상태로 변경
                _stateMachine.ChangeState(_attackState);
            }
            else // 멈추지 않아도 된다면
            {
                _stateMachine.ChangeState(_moveState);
            }

            _stateMachine.Execute(); // 현재 상태에서 매 프레임 실행되어야 하는 코드를 가지는 함수
        }

        public void Hit(int damage)
        {
            _stateMachine.ChangeState(_hitState);
            _health.Hit(damage);
        }
    }
}
// 마지막 작성 일자: 2026.09.21