using Util.FSM.Interface;

namespace Util.FSM
{
    public class StateMachine
    {
        public IState CurrentState { get => _currentState; } // 현재 상태 프로퍼티
        private IState _currentState; // 현재 상태

        // 상태 시작 함수
        private void StateEnter(IState state)
        {
            // 같은 상태라면
            if (state == _currentState)
            {
                return; // 반환
            }

            // 현재 상태 종료 함수 호출
            _currentState?.OnExit();

            // 현재 상태 변경
            _currentState = state;

            // 현재 상태 시작 함수 호출
            _currentState.OnEnter();
        }

        // 초기화 함수
        public void Init(IState startState)
        {
            StateEnter(startState);
        }

        // 상태 변경 함수
        public void ChangeState(IState nextState)
        {
            StateEnter(nextState);
        }

        // 현재 상태에서 매 프레임 실행되는 함수
        public void Execute()
        {
            _currentState?.OnExecute();
        }
    }
}
// 마지막 작성 일자: 2026.09.18