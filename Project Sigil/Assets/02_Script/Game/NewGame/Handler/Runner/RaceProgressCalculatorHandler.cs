using UnityEngine;

namespace Game.Handler.Runner
{
    // 작성자: 조혜찬
    // 경기 진행률 계산기
    public class RaceProgressCalculatorHandler
    {
        private float _totalDistance;               // 총 거리
        private float _currentDistance = 0;         // 현재까지 이동한 거리

        public RaceProgressCalculatorHandler(float totalDistance)
        {
            _totalDistance = totalDistance;
        }

        // 현재 위치 값 반환 함수
        public float ProgressIncreaseValue(float distance)
        {
            // 현재 위치 + 이동 거리
            _currentDistance += distance;

            // 진행률 변화량 (현재 위치 / 총 거리)
            float progressDelta = _currentDistance / _totalDistance;

            return progressDelta;
        }

        // 남은 거리 반환 함수
        public float GetLeftDistance()
        {
            // 남은 거리 (총 거리 - 현재 위치)
            int leftDistance = (int)(_totalDistance - _currentDistance);

            return leftDistance;
        }
    }
}
// 마지막 작성 일자: 2026.11.18