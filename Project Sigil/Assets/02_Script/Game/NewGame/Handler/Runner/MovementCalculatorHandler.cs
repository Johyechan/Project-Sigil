using UnityEngine;

namespace Game.Handler.Runner
{
    // 작성자: 조혜찬
    // 이동 관련 계산기
    public class MovementCalculatorHandler
    {
        private float _timeScale;       // 경기 시간 배율
        private float _speed;           // 속력 - 임시

        public MovementCalculatorHandler(float timeScale, float speed)
        {
            _timeScale = timeScale;
            _speed = speed;
        }

        // 이동 거리 반환 함수
        public float GetMoveDistance()
        {
            // 이동 거리 = 속력 * 프레임 당 시간 * 시간 배율
            float moveDistance = GetSpeed() * Time.deltaTime * _timeScale;

            return moveDistance;
        }

        // 속력 반환 함수
        private float GetSpeed()
        {
            // 현재 속력
            float currentSpeed = _speed;

            // 현재 속력를 km/h에서 m/s로 변환 
            float speed = currentSpeed / 3.6f;

            return speed;
        }
    }
}
// 마지막 작성 일자: 2026.11.18