using UnityEngine;

namespace Game.Enemy
{
    // 작성자: 조혜찬
    // 적 체력 클래스
    public class EnemyHealth
    {
        private int _currentHp; // 현재 체력

        public EnemyHealth(int maxHp)
        {
            _currentHp = maxHp;
        }

        // 맞았을 때 함수
        public void Hit(int damage)
        {
            _currentHp -= damage;
        }

        // 사망 여부
        public bool IsDie()
        {
            // 현재 체력이 0 이하면 사망 판정
            return _currentHp <= 0;
        }
    }
}
// 마지막 작성 일자: 2026.09.21