using UnityEngine;

namespace Game.Enum
{
    // 작성자: 조혜찬
    // 경기 스타일 - 선수가 경기를 풀어나가는 방식
    public enum RaceStyle
    {
        FastStarter = 0,        // 초반 질주형
        StrongFinisher,         // 후반 집중형
        PaceKeeper,             // 페이스 유지형
        AccelerationSpecialist  // 가속 특화형
    }
}
// 마지막 작성 일자: 2026.10.23