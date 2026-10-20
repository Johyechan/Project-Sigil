using UnityEngine;

namespace Game
{
    // 작성자: 조혜찬
    // 피격 인터페이스
    public interface IHit
    {
        public void OnHit(int damage);
    }
}
// 마지막 작성 일자: 2026.09.18