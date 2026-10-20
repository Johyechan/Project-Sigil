using Util.FSM.Interface;

namespace Game.Enemy.State
{
    // 작성자: 조혜찬
    // 적 이동 상태
    public class EnemyMoveState : IState
    {
        private EnemyMovement _movement; // 적 이동 클래스

        public EnemyMoveState(EnemyMovement movement)
        {
            _movement = movement;
        }

        public void OnEnter()
        {
            
        }

        public void OnExecute()
        {
            _movement.Move();
        }

        public void OnExit()
        {
            
        }
    }
}
// 마지막 작성 일자: 2026.09.16