using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어의 인풋을 관리하는 클래스
    public class PlayerInput
    {
        public Vector2 MoveInput { get; private set; } // 이동 벡터 프로퍼티

        private InputActionAsset _playerInputActionAsset; // 플레이어 인풋 에셋

        private InputActionMap _playerActionMap; // 플레이어 인풋 에셋에 있는 액션 맵

        private InputAction _moveAction; // 이동 액션

        public PlayerInput(InputActionAsset inputActionAsset)
        {
            _playerInputActionAsset = inputActionAsset;
        }

        public void Init()
        {
            _playerActionMap = _playerInputActionAsset.FindActionMap("Player"); // Player라는 이름을 가지는 맵을 탐색 후 할당
            _moveAction = _playerActionMap.FindAction("Move"); // Player맵에서 Move라는 이름을 가지는 액션 탐색 후 할당
        }

        // 활성화 시 실행 함수
        public void Enable()
        {
            _moveAction.Enable(); // 액션 활성화
            _moveAction.performed += OnMove; // 콜백 함수 구독
            _moveAction.canceled += OnMoveCanceled; // 콜백 함수 구독
        }

        // 비활성화 시 실행 함수
        public void Disable()
        {
            _moveAction.performed -= OnMove; // 콜백 함수 구독 해제
            _moveAction.canceled -= OnMoveCanceled; // 콜백 함수 구독 해제
            _moveAction.Disable(); // 액션 비활성화
        }

        // 액션이 수행 됐을 때 콜백 함수
        private void OnMove(InputAction.CallbackContext callbackContext)
        {
            // 이동 벡터 설정
            MoveInput = callbackContext.ReadValue<Vector2>();
        }

        // 입력이 끝났을 때 콜백 함수
        private void OnMoveCanceled(InputAction.CallbackContext callbackContext)
        {
            MoveInput = Vector2.zero;
        }
    }
}
// 마지막 작성 일자; 2026.09.14