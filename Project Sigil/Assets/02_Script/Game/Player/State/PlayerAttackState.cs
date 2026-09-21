using UnityEngine;
using Util.FSM.Interface;

namespace Game.Player.State
{
    // 작성자: 조혜찬
    // 플레이어 공격 상태
    public class PlayerAttackState : IState
    {
        private MonoBehaviour _behaviour;

        private PlayerAttack _attack;

        public PlayerAttackState(MonoBehaviour behaviour, PlayerAttack attack)
        {
            _behaviour = behaviour;
            _attack = attack;
        }

        public void OnEnter()
        {
            _behaviour.StartCoroutine(_attack.DrawSigil(_behaviour));
        }

        public void OnExecute()
        {
            
        }

        public void OnExit()
        {
            
        }
    }
}
// 마지막 작성 일자: 2026.09.21