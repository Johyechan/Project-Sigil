using System.Collections;
using UnityEngine;

namespace Game.Sigil
{
    // 작성자: 조혜찬
    // 문양 인터페이스
    public interface ISigil
    {
        // 문양 그리는 함수
        public IEnumerator DrawSigil(SigilScriptableObject sigilData, Transform parent);
    }
}
// 마지막 작성 일자: 2026.09.21