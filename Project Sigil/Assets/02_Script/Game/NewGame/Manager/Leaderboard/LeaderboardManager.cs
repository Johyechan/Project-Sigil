using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 순위표 관리자
    public class LeaderboardManager : MonoBehaviour
    {
        private static LeaderboardManager _instance;
        public static LeaderboardManager Instance { get => _instance; }

        [SerializeField] private List<RunnerRank> _runnerList = new List<RunnerRank>(); // 달리기 선수 랭크 목록
        public List<RunnerRank> RunnerList { get => _runnerList; }
        private List<RunnerRank> rankingList = new List<RunnerRank>();                  // 순위 목록

        [SerializeField] private float _rankingListInterval;                            // 순위 목록 간격

        private void Awake()
        {
            _instance = this;

            foreach (var runner in RunnerList)
            {
                rankingList.Add(runner);
            }
        }

        private void Update()
        {
            ToRank();
        }

        private void ToRank()
        {
            rankingList.Sort((a, b) => b.CurrentPos.CompareTo(a.CurrentPos)); // 내림차순으로 정렬

            int count = 1;
            foreach(var rank in rankingList)
            {
                float x = rank.Rect.anchoredPosition.x;
                rank.Rect.anchoredPosition = new Vector2(x, _rankingListInterval * count);
                count++;
            }
        }
    }
}
// 마지막 작성 일자: 2026.11.19