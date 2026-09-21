using UnityEngine;
using Util.Pool;

// 작성자: 조혜찬
// 적 정보
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy/Enemy Data", order = 0)]
public class EnemyScriptableObject : ScriptableObject
{
    [SerializeField] private PoolType type;

    [SerializeField] private int maxHp;
    [SerializeField] private int damage;

    [SerializeField] private float speed;
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackSpeed;

    public PoolType Type { get => type; } // 적 타입

    public int MaxHp { get => maxHp; } // 최대 체력
    public int Damage { get => damage; } // 피해량

    public float Speed { get => speed; } // 이동 속도
    public float AttackDistance { get => attackDistance; } // 공격 거리
    public float AttackSpeed { get => attackSpeed; } // 공격 속도(시간 간격)
}
// 마지막 작성 일자: 2026.09.21