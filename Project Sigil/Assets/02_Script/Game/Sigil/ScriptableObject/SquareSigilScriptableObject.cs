using UnityEngine;

// 작성자: 조혜찬
// 사각형 문양 데이터
[CreateAssetMenu(fileName = "SquareSigilData", menuName = "Game/Sigil/Square Sigil Data", order = 2)]
public class SquareSigilScriptableObject : SigilScriptableObject
{
    [SerializeField] private Vector3 bottomStartPos; // 밑 변 시작점
    [SerializeField] private Vector3 bottomEndPos; // 밑 변 끝점

    [SerializeField] private Vector3 leftStartPos; // 왼쪽 변 시작점
    [SerializeField] private Vector3 leftEndPos; // 왼쪽 변 끝점

    [SerializeField] private Vector3 topStartPos; // 윗 변 시작점
    [SerializeField] private Vector3 topEndPos; // 윗 변 끝점

    [SerializeField] private Vector3 rightStartPos; // 오른쪽 변 시작점
    [SerializeField] private Vector3 rightEndPos; // 오른쪽 변 끝점

    [SerializeField] private float delay; // 지연 시간

    [SerializeField] private int _lineBulletCount; // 변을 구성하는 총알 개수

    public Vector3 BottomStartPos { get => bottomStartPos; }
    public Vector3 BottomEndPos { get => bottomEndPos; }

    public Vector3 LeftStartPos { get => leftStartPos; }
    public Vector3 LeftEndPos { get => leftEndPos; }

    public Vector3 TopStartPos { get => topStartPos; }
    public Vector3 TopEndPos { get => topEndPos; }

    public Vector3 RightStartPos { get => rightStartPos; }
    public Vector3 RightEndPos { get => rightEndPos; }

    public float Delay { get => delay; }

    public int LineBulletCount { get => _lineBulletCount; }
}
// 마지막 작성 일자: 2026.10.06