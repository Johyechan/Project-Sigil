using Game.Player.State;
using Game.Sigil;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Util.FSM.Interface;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어 행동 제어 클래스
    public class PlayerController : MonoBehaviour
    {
        // 원 문양 데이터
        [SerializeField] private CircleSigilScriptableObject _circleSigilData;

        // 사용할 인풋 에셋
        [SerializeField] private InputActionAsset _playerInputActionAsset;

        // 문양 대기 시간
        [SerializeField] private float _sigilWaitTime;
        // 이동 속도
        [SerializeField] private float _speed;

        // 플레이어 이동 클래스
        private PlayerMovement _playerMovement;

        // 플레이어 인풋 관리 클래스
        private PlayerInput _playerInput;

        // 플레이어 공격 클래스
        private PlayerAttack _playerAttack;

        // 플레이어 상태 관리
        private PlayerStateMachine _stateMachine;

        private IState _idleState;
        private IState _moveState;
        private IState _attackState;

        private Coroutine _currentCo;

        private void Awake()
        {
            _playerMovement = new PlayerMovement(transform, _speed);
            _playerInput = new PlayerInput(_playerInputActionAsset);
            _playerInput.Init();
            _playerAttack = new PlayerAttack(_circleSigilData, transform);
            _playerAttack.Init();

            _idleState = new PlayerIdleState();
            _moveState = new PlayerMoveState(_playerMovement, _playerInput);
            _attackState = new PlayerAttackState(this, _playerAttack);

            _stateMachine = new PlayerStateMachine(_idleState, _moveState, _attackState, _playerInput, _playerAttack);
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Update()
        {
            _stateMachine.Execute();
        }

        public void Attack(int type)
        {
            if(_currentCo != null)
            {
                StopCoroutine(_currentCo);
                _currentCo = null;
            }

            _currentCo = StartCoroutine(AttackStartCo((SigilType)type));
        }

        private IEnumerator AttackStartCo(SigilType type)
        {
            yield return new WaitForSeconds(_sigilWaitTime);

            _playerAttack.Attack(type);
        }
    }
}
// 마지막 작성 일자: 2026.09.21