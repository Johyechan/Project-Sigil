using TMPro;
using UnityEngine;

namespace Game
{
    // 작성자: 조혜찬
    // 달리기 선수 순위 메인 클래스
    public class RunnerRank : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _rank;

        private RectTransform _rect;
        public RectTransform Rect { get => _rect; }

        public int Ranking { get; set; } // 현재 순위
        public int CurrentPos { get; set; } // 현재 위치

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
        }
    }
}
// 마지막 작성 일자: 2026.11.19