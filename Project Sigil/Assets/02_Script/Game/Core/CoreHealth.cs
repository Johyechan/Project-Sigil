using UnityEngine;

namespace Game.Core
{
    // 작성자: 조혜찬
    // 코어 체력 관리 클래스
    public class CoreHealth : IHit
    {
        private int _maxHp; // 최대 체력
        private int _currentHp; // 현재 체력
        
        public CoreHealth(int maxHp)
        {
            _maxHp = maxHp;
            _currentHp = _maxHp;
            Debug.Log($"처음 체력: {_currentHp}");
        }

        // 피격 시 실행 함수
        public void OnHit(int damage)
        {
            // 현재 체력이 0보다 클 때
            if(_currentHp > 0)
            {
                // 현재 체력 - 데미지
                _currentHp -= damage;
                Debug.Log($"현재 체력: {_currentHp}");
            }
            else // 현재 체력이 0 이하일 때
            {
                Debug.Log($"코어 파괴됨");
            }
        }
    }
}
// 마지막 작성 일자: 2026.09.18