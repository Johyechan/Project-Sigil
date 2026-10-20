using UnityEngine;

namespace Game.Core
{
    // 작성자: 조혜찬
    // 코어 제어 클래스
    public class CoreController : MonoBehaviour, IHit
    {
        [SerializeField] private CoreScriptableObject _data; // 코어 정보

        private CoreHealth _health; // 코어 체력 관리 클래스

        private void Awake()
        {
            _health = new CoreHealth(_data.MaxHp);
        }

        // 피격 시 실행 함수(외부에서 접근 가능한 함수)
        public void OnHit(int damage)
        {
            _health.OnHit(damage);
        }
    }
}
// 마지막 작성 일자: 2026.09.18