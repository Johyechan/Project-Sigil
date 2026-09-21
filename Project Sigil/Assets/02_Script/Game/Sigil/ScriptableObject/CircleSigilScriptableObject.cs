using UnityEngine;

// 작성자: 조혜찬
// 문양 데이터
[CreateAssetMenu(fileName = "CircleSigilData", menuName = "Game/Sigil/Circle Sigil Data")]
public class CircleSigilScriptableObject : SigilScriptableObject
{
    [SerializeField] private float delay;
    [SerializeField] private float radius;

    public float Delay { get => delay; } // 지연 시간
    public float Radius { get => radius; } // 플레이어와 떨어진 길이(반지름)
}
// 마지막 작성 일자: 2026.09.21