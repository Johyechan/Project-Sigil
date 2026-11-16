using System;
using UnityEngine;

namespace Game.Manager.RaceProgress
{
    // 작성자: 조혜찬
    // 경주 진행 상황 관리자
    public class RaceProgressManager : MonoBehaviour
    {
        private static RaceProgressManager _instance;
        public static RaceProgressManager Instance => _instance;    // 외부에서 접근하기 위한 인스턴스

        public event Action RaceStartEvent;                        // 레이스 시작 이벤트

        private void Awake()
        {
            _instance = this;                                       // 인스턴스 초기화
        }

        private void Start()
        {
            RaceStartEvent?.Invoke();
        }
    }
}
// 마지막 작성 일자: 2026.11.16