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

        private SpeedCalculateHandler _speedCalculateHandler;
        private LeftDistanceCalculateHandler _leftDistanceCalculateHandler;
        private ProgressCalculateHandler _progressCalculateHandler;

        private void Awake()
        {
            _speedCalculateHandler = new SpeedCalculateHandler();
            _leftDistanceCalculateHandler = new LeftDistanceCalculateHandler();
            _progressCalculateHandler = new ProgressCalculateHandler();
        }

        private void Update()
        {
            // 현재 속도
            float currentSpeed = _speedCalculateHandler.GetSpeed();

            _progress.value += _progressCalculateHandler.ProgressIncreaseValue(currentSpeed);
            _leftDistanceText.text = $"{_leftDistanceCalculateHandler.GetLeftDistance(currentSpeed)}m";
        }
    }
}
// 마지막 작성 일자: 2026.11.17