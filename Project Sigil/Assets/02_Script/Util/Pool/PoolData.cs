using System;
using UnityEngine;

namespace Util.Pool
{
    // 작성자: 조혜찬
    // 풀링 정보
    [Serializable]
    public class PoolData
    {
        public int count; // 풀에 추가할 오브젝트 수
        public PoolType type; // 풀 타입
        public GameObject obj; // 풀 객체
    }
}
// 마지막 작성 일자: 2026.09.21