using UnityEngine;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어 이동 클래스
    public class PlayerMovement
    {
        private Transform _player; // 플레이어

        private float _speed; // 이동 속도

        public PlayerMovement(Transform player, float speed)
        {
            _player = player;
            _speed = speed;
        }

        // 이동 콜백 함수
        public void Move(Vector2 inputVector)
        {
            // 이동 방향 구하기(대각선으로 움직일 때도 같은 속도로 이동하기 위해서 정규화)
            Vector3 direction = inputVector.normalized;

            // 플레이어를 direction 방향으로 이번 프레임 동안 이동해야할 거리만큼 더해주기
            _player.position += direction * _speed * Time.deltaTime;
        }
    }
}
// 마지막 작성 일자: 2026.09.14