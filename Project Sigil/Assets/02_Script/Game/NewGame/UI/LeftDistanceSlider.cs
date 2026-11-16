using Game.Manager.RaceProgress;
using System.Collections;
using UnityEngine;

namespace Game.UI
{
    // 작성자: 조혜찬
    // 남은 거리 보여주는 슬라이더 처리 클래스
    public class LeftDistanceSlider : MonoBehaviour
    {
        [SerializeField] private int _lane; // 뛰는 위치

        private void OnEnable()
        {
            RaceProgressManager.Instance.RaceStartEvent += StartRunning;
        }

        private void OnDisable()
        {
            RaceProgressManager.Instance.RaceStartEvent -= StartRunning;
        }

        // 달리기 시작 함수
        private void StartRunning()
        {
            StartCoroutine(RunningCo());
        }

        // 달리기 코루틴
        private IEnumerator RunningCo()
        {
            yield return new();
        }
    }
}
// 마지막 작성 일자: 2026.11.16