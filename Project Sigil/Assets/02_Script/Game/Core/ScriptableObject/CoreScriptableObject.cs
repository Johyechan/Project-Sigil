using UnityEngine;

// 작성자: 조혜찬
// 코어 정보
[CreateAssetMenu(fileName = "CoreData", menuName = "Game/Core Data", order = 1)]
public class CoreScriptableObject : ScriptableObject
{
    [SerializeField] private int maxHp;

    public int MaxHp { get => maxHp; } // 최대 체력
}
// 마지막 작성 일자: 2026.09.18