using UnityEngine;
using Util.FSM.Interface;

namespace Game.Enemy.State
{
    // 작성자: 조혜찬
    // 적 피격 상태
    public class EnemyHitState : IState
    {
        public void OnEnter()
        {
            Debug.Log("총알 맞음");
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