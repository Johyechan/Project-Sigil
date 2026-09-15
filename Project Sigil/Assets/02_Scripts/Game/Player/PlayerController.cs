using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어 행동 제어 클래스
    public class PlayerController : MonoBehaviour
    {
        // 사용할 인풋 에셋
        [SerializeField] private InputActionAsset _playerInputActionAsset;

        // 이동 속도
        [SerializeField] private float _speed;

        // 플레이어 이동 클래스
        private PlayerMovement _playerMovement;

        // 플레이어 인풋 관리 클래스
        private PlayerInput _playerInput;

        private void Awake()
        {
            _playerMovement = new PlayerMovement(transform, _speed);
            _playerInput = new PlayerInput(_playerInputActionAsset);
            _playerInput.Init();
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
            _playerMovement.Move(_playerInput.MoveInput);
        }
    }
}
// 마지막 작성 일자: 2026.09.14