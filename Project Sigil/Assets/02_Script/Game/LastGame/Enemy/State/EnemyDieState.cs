using UnityEngine;
using Util.FSM.Interface;
using Util.Pool;

namespace Game.Enemy.State
{
    // 작성자: 조혜찬
    // 적 사망 상태
    public class EnemyDieState : IState
    {
        private PoolType _type;

        private GameObject _self;

        public EnemyDieState(PoolType type, GameObject self)
        {
            _type = type;
            _self = self;
        }

        public void OnEnter()
        {
            // 풀에 객체 반환
            ObjectPool.Instance.ReturnObject(_type, _self);
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