using UnityEngine;

namespace Game
{
    // 작성자: 조혜찬
    // 영역 확인 클래스
    public static class CheckArea
    {
        // 원형 영역 체크
        public static GameObject CheckCircle(Vector2 origin, float radius, Vector2 direction, float distance = 0, string layerMaskName = "Default")
        {
            RaycastHit2D hit = Physics2D.CircleCast(origin, radius, direction, distance, LayerMask.NameToLayer(layerMaskName));

            // 코어가 영역 안에 있다면
            if (hit.collider != null)
            {
                // 코어 객체 반환
                return hit.collider.gameObject;
            }

            return null;
        }
    }
}
// 마지막 작성 일자: 2026.09.18