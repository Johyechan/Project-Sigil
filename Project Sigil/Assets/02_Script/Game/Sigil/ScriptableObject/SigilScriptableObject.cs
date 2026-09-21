using UnityEngine;

// 작성자: 조혜찬
// 문양 데이터
public class SigilScriptableObject : ScriptableObject
{
    [SerializeField] protected float bulletCount;
    [SerializeField] protected float bulletSpeed;

    public float BulletCount { get => bulletCount; } // 총알 개수
    public float BulletSpeed { get => bulletSpeed; } // 총알 속도
}
// 마지막 작성 일자: 2026.09.21