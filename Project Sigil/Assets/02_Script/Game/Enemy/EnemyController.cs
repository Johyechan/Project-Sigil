using Game.Enemy.State;
using UnityEngine;
using Util.FSM.Interface;

namespace Game.Enemy
{
    // 작성자: 조혜찬
    // 적 제어 클래스
    public class EnemyController : MonoBehaviour, IHit
    {
        private Transform _target; // 목표 대상

        [SerializeField] private EnemyScriptableObject _data; // 적 정보

        private EnemyHealth _health; // 적 체력 클래스
        private EnemyMovement _movement; // 적 이동 클래스
        private EnemyAttack _attack; // 적 공격 클래스
        private EnemyStateMachine _machine; // 적 상태 관리 머신

        private IState _idleState; // 기본 상태
        private IState _moveState; // 이동 상태
        private IState _attackState; // 공격 상태
        private IState _hitState; // 피격 상태
        private IState _dieState; // 사망 상태

        private void Awake()
        {
            _target = GameObject.Find("Core").transform;

            _health = new EnemyHealth(_data.MaxHp);
            _movement = new EnemyMovement(_target, transform, _data.Speed, _data.AttackDistance);
            _attack = new EnemyAttack(this, transform, _data.AttackDistance, _data.AttackSpeed, _data.Damage);

            _idleState = new EnemyIdleState();
            _moveState = new EnemyMoveState(_movement);
            _attackState = new EnemyAttackState(_attack);
            _hitState = new EnemyHitState();
            _dieState = new EnemyDieState(_data.Type, gameObject);

            _machine = new EnemyStateMachine(_idleState, _moveState, _attackState, _hitState, _dieState, _movement, _health);
        }

        private void OnEnable()
        {
            _machine.Init();
        }

        private void Update()
        {
            _machine.Execute();
        }

        public void OnHit(int damage)
        {
            _machine.Hit(damage);
        }
    }
}
// 마지막 작성 일자: 2026.09.21