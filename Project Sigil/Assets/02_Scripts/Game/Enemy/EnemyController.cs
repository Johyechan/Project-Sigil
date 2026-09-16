using Game.Enemy.State;
using UnityEngine;
using Util.FSM.Interface;

namespace Game.Enemy
{
    // 작성자: 조혜찬
    // 적 제어 클래스
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform _target; // 목표 대상

        [SerializeField] private EnemyScriptableObject _data; // 적 정보

        private EnemyMovement _movement; // 적 이동 클래스
        private EnemyStateMachine _machine; // 적 상태 관리 머신

        private IState _idleState; // 기본 상태
        private IState _moveState; // 이동 상태

        private void Awake()
        {
            _movement = new EnemyMovement(_target, transform, _data.Speed, _data.StopDistance);

            _idleState = new EnemyIdleState();
            _moveState = new EnemyMoveState(_movement);

            _machine = new EnemyStateMachine(_idleState, _moveState, _movement);
            _machine.Init();
        }

        private void Update()
        {
            _machine.Execute();
        }
    }
}
// 마지막 작성 일자: 2026.09.16