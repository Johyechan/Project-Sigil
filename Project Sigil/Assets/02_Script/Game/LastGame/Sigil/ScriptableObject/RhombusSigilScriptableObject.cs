using UnityEngine;

// 작성자: 조혜찬
// 마름모 문양 데이터
[CreateAssetMenu(fileName = "RhombusSigilData", menuName = "Game/Sigil/Rhombus Sigil Data", order = 3)]
public class RhombusSigilScriptableObject : SigilScriptableObject
{
    [SerializeField] private Vector3 topToLeftStartPos; // 위에 있는 슬래시 형태의 변 시작점
    [SerializeField] private Vector3 topToLeftEndPos; // 위에 있는 슬래시 형태의 변 끝점

    [SerializeField] private Vector3 leftToBottomStartPos; // 아래 있는 백 슬래시 형태의 변 시작점
    [SerializeField] private Vector3 leftToBottomEndPos; // 아래 있는 백 슬래시 형태의 변 끝점

    [SerializeField] private Vector3 bottomToRightStartPos; // 아래 있는 슬래시 형태의 변 시작점
    [SerializeField] private Vector3 bottomToRightEndPos; // 아래 있는 슬래시 형태의 변 끝점

    [SerializeField] private Vector3 rightToTopStartPos; // 위에 있는 백 슬래시 형태의 변 시작점
    [SerializeField] private Vector3 rightToTopEndPos; // 위에 있는 백 슬래시 형태의 변 끝점

    [SerializeField] private int lineBulletCount; // 한 변을 그리는데 필요한 총알 개수

    [SerializeField] private float delay; // 지연 시간

    public Vector3 TopToLeftStartPos { get => topToLeftStartPos; }
    public Vector3 TopToLeftEndPos { get => topToLeftEndPos; }

    public Vector3 LeftToBottomStartPos { get => leftToBottomStartPos; }
    public Vector3 LeftToBottomEndPos { get => leftToBottomEndPos; }

    public Vector3 BottomToRightStartPos { get => bottomToRightStartPos; }
    public Vector3 BottomToRightEndPos { get => bottomToRightEndPos; }

    public Vector3 RightToTopStartPos { get => rightToTopStartPos; }
    public Vector3 RightToTopEndPos { get => rightToTopEndPos; }

    public int LineBulletCount { get => lineBulletCount; }

    public float Delay { get => delay; }
}
// 마지막 작성 일자: 2026.10.07