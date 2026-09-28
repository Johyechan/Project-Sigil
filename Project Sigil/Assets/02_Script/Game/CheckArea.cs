using UnityEngine;

namespace Game
{
    // 작성자: 조혜찬
    // 영역 확인 클래스
    public static class CheckArea
    {
        // 원형 영역 체크
        public static GameObject CheckObjectInCircle(Vector2 origin, float radius, Vector2 direction, float distance = 0, string layerMaskName = "Default")
        {
            RaycastHit2D hit = Physics2D.CircleCast(origin, radius, direction, distance, LayerMask.GetMask(layerMaskName));
            
            // 영역 안에 객체가 있다면
            if (hit.collider != null)
            {
                // 객체 반환
                return hit.collider.gameObject;
            }

            return null;
        }

        // 원형 영역 체크(객체들을 전부 반환)
        public static GameObject[] CheckObjectsInCircle(Vector2 origin, float radius, Vector2 direction, float distance = 0, string layerMaskName = "Default")
        {
            RaycastHit2D[] hit = Physics2D.CircleCastAll(origin, radius, direction, distance, LayerMask.GetMask(layerMaskName));

            // 영역 안에 객체가 하나 이상 있다면
            if (hit.Length > 0)
            {
                GameObject[] objects = new GameObject[hit.Length];

                for(int i = 0; i < hit.Length; i++)
                {
                    objects[i] = hit[i].collider.gameObject;
                }
                // 객체들 반환
                return objects;
            }

            return null;
        }
    }
}
// 마지막 작성 일자: 2026.09.28