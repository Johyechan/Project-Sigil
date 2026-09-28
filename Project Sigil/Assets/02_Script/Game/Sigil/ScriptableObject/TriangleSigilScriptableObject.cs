using UnityEngine;

// 작성자: 조혜찬
// 삼각형 문양 데이터
[CreateAssetMenu(fileName = "TriangleSigilData", menuName = "Game/Sigil/Triangle Sigil Data")]
public class TriangleSigilScriptableObject : SigilScriptableObject
{
    [SerializeField] private int underBulletCount; // 밑 변 총알 개수
    [SerializeField] private int sideBulletCount; // 옆 변 총알 개수

    [SerializeField] private float underBulletInterval; // 밑 변 총알 간격
    [SerializeField] private float underLineY; // 밑 변 y 축 위치
    [SerializeField] private float topDotY; // 위 꼭짓점 y축 위치
    [SerializeField] private float delay; // 지연 시간
    [SerializeField] private float sectorFormRange; // 부채꼴 범위


    public int UnderBulletCount { get => underBulletCount; }
    public int SideBulletCount { get => sideBulletCount; }

    public float UnderBulletInterval { get => underBulletInterval; }
    public float UnderLineY { get => underLineY; }
    public float TopDotY { get => topDotY; }
    public float Delay { get => delay; }
    public float SectorFormRange { get => sectorFormRange; }
}
// 마지막 작성 일자: 2026.09.28