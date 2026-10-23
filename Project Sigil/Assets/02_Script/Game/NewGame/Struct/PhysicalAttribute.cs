using UnityEngine;

namespace Game.Struct
{
    // 작성자: 조혜찬
    // 선수 신체 능력치 구조체
    public struct PhysicalAttribute
    {
        public float MaxSpeed;              // 최대 속력
        public float Endurance;             // 지구력
        public float Acceleration;          // 가속력
        public float ReactionTime;          // 반응 시간

        public float MaxSpeedPotential;     // 최대 속력 잠재력
        public float EndurancePotential;    // 지구력 잠재력
        public float AccelerationPotential; // 가속력 잠재력
        public float ReactionTimePotential; // 반응 시간 잠재력
    }
}
// 마지막 작성 일자: 2026.10.23