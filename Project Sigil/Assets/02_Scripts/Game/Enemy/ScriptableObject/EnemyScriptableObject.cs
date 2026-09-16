using UnityEngine;

// 작성자: 조혜찬
// 적 정보
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data", order = 0)]
public class EnemyScriptableObject : ScriptableObject
{
    public int MaxHp; // 최대 체력
    public int Damage; // 피해량

    public float Speed; // 이동 속도
    public float StopDistance; // 멈춰야 하는 거리
}
// 마지막 작성 일자: 2026.09.16