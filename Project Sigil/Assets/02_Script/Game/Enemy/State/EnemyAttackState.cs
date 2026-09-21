using Util.FSM.Interface;

namespace Game.Enemy.State
{
    // 작성자: 조혜찬
     // 적 공격 상태
    public class EnemyAttackState : IState
    {
        private EnemyAttack _attack;

        public EnemyAttackState(EnemyAttack attack)
        {
            _attack = attack;
        }

        public void OnEnter()
        {
            _attack.Attack();
        }

        public void OnExecute()
        {
            
        }

        public void OnExit()
        {
            _attack.AttackStop();
        }
    }
}
// 마지막 작성 일자: 2026.09.18