using Game.Handler.Runner;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    // 작성자: 조혜찬
    // 달리기 선수 메인 클래스
    public class Runner : MonoBehaviour
    {
        [SerializeField] private Slider _progress; // 진행률 슬라이더
        [SerializeField] private TMP_Text _leftDistanceText; // 남은 거리 텍스트

        // 임시 변수들
        [SerializeField] private float _speed; // 속력
        [SerializeField] private float _timeScale; // 시간 배율
        [SerializeField] private float _totalDistance; // 총 거리

        private MovementCalculatorHandler _movementCalculatorHandler;
        private RaceProgressCalculatorHandler _raceProgressCalculatorHandler;

        private void Awake()
        {
            _movementCalculatorHandler = new MovementCalculatorHandler(_timeScale, _speed);
            _raceProgressCalculatorHandler = new RaceProgressCalculatorHandler(_totalDistance);
        }

        private void Update()
        {
            // 이동 거리
            float currentMoveDistance = _movementCalculatorHandler.GetMoveDistance();

            _progress.value = _raceProgressCalculatorHandler.ProgressIncreaseValue(currentMoveDistance);
            _leftDistanceText.text = $"{_raceProgressCalculatorHandler.GetLeftDistance()}m";
        }
    }
}
// 마지막 작성 일자: 2026.11.18