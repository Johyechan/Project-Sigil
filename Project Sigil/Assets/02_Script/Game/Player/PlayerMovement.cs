using UnityEngine;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 플레이어 이동 클래스
    public class PlayerMovement
    {
        private Transform _player; // 플레이어
        private Transform _core; // 코어

        private float _speed; // 이동 속도
        private float _maxDistance; // 최대 거리

        public PlayerMovement(Transform player, Transform core, float speed, float maxDistance)
        {
            _player = player;
            _speed = speed;
            _core = core;
            _maxDistance = maxDistance;
        }

        // 이동 콜백 함수
        public void Move(Vector2 inputVector)
        {
            // 이동 방향 구하기(대각선으로 움직일 때도 같은 속도로 이동하기 위해서 정규화)
            Vector3 direction = inputVector.normalized;

            Vector3 nextPosition = _player.position + direction * _speed * Time.deltaTime;

            // 플레이어와 코어의 거리가 최대 거리 미만이라면
            if (Vector3.Distance(_core.position, nextPosition) < _maxDistance)
            {
                // 플레이어는 다음 이동 위치로 이동
                _player.position = nextPosition;
            }
            else // 최대 거리 이상이라면
            {
                // 현재 위치에서 원의 바깥쪽 방향
                Vector3 normal = (_player.position - _core.position).normalized;
                // 이동 방향에 바깥쪽 방향 성분이 얼마나 포함되어 있는지 확인
                float outWard = Vector3.Dot(direction, normal);
                // 이동 방향에 포함된 바깥쪽 성분
                Vector3 outWardVector = normal * outWard;
                // 바깥쪽 성분을 제거
                Vector3 allowedDirection = direction - outWardVector;
                // 바깥쪽 성분을 제거한 방향으로 이동
                _player.position += allowedDirection * _speed * Time.deltaTime;
            }
        }
    }
}
// 마지막 작성 일자: 2026.09.30