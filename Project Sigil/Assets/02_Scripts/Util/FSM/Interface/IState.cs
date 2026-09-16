namespace Util.FSM.Interface
{
    // 작성자: 조혜찬
    // FSM 상태 인터페이스
    public interface IState
    {
        // 상태 시작 함수
        public void OnEnter();

        // 상태 실행 함수
        public void OnExecute();

        // 상태 종료 함수
        public void OnExit();
    }
}
// 마지막 작성 일자: 2026.09.16