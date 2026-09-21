using UnityEngine;
using Util.Pool;

[CreateAssetMenu(fileName = "BulletData", menuName = "Game/Bullet/Bullet Data", order = 1)]
public class BulletScriptableObject : ScriptableObject
{
    [SerializeField] protected PoolType _type; // 총알 종류

    [SerializeField] protected float _lifeTime; // 총알 생존 시간

    [SerializeField] protected int _damage; // 총알 피해량

    public PoolType Type { get => _type; } // 총알 종류 프로퍼티

    public float LifeTime { get => _lifeTime; } // 총알 생존 시간 프로퍼티

    public int Damage { get => _damage; } // 총알 피해량 프로퍼티
}
// 마지막 작성 일자: 2026.09.21