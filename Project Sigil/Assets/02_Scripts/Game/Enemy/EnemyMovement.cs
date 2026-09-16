using UnityEngine;

namespace Game.Enemy
{
    // 작성자: 조혜찬
    // 적 이동 클래스
    public class EnemyMovement
    {
        private Transform _target; // 목표 대상
        private Transform _self; // 자기 자신

        private float _speed; // 이동 속도
        private float _stopDistance; // 멈춰야 하는 거리

        public EnemyMovement(Transform target, Transform self, float speed, float stopDistance)
        {
            _target = target;
            _self = self;
            _speed = speed;
            _stopDistance = stopDistance;
        }

        // 이동 함수
        public void Move()
        {
            // 이동 방향
            Vector3 direction = _target.position - _self.position;

            // 이동 방향으로 이동
            _self.position += direction.normalized * _speed * Time.deltaTime;
        }

        // 멈춰야 하는지 확인하는 함수
        public bool ShouldStop()
        {
            // 목표 대상과의 거리가 멈춰야 하는 거리 이하라면
            if(Vector3.Distance(_target.position, _self.position) <= _stopDistance)
            {
                return true;
            }

            return false;
        }
    }
}
// 마지막 작성 일자: 2026.09.16