using System.Collections.Generic;
using UnityEngine;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 트랙 매니저
    public class TrackManager : MonoBehaviour
    {
        [SerializeField] private Transform _trackParent; // 트랙 부모 객체

        [SerializeField] private List<Material> _lineMaterials; // 라인랜더러 머티리얼

        [SerializeField] private int _trackCount; // 트랙 개수
        [SerializeField] private int _pointCount; // 점 개수

        [SerializeField] private float _size; // 도형 크기
        [SerializeField] private float _width; // 선 두께

        private void Start()
        {
            CreateTrack();
        }

        // 트랙 생성 함수
        private void CreateTrack()
        {
            // 트랙 _trackCount 수만큼 만들기
            for(int i = 0; i < _trackCount; i++)
            {
                GameObject track = new GameObject($"{i} track"); // 트랙 객체 생성
                track.transform.SetParent(_trackParent); // _trackParent를 트랙 객체의 부모로 지정
                LineRenderer trackLine = track.AddComponent<LineRenderer>(); // 트랙 객체에 LineRenderer 추가
                trackLine.SetMaterials(_lineMaterials); // 머티리얼 설정
                trackLine.startWidth = _width; // 시작 두께
                trackLine.endWidth = _width; // 끝 두께
                trackLine.loop = true; // 끝점과 시작점 연결

                trackLine.positionCount = _pointCount; // 라인 랜더러 점 개수
                for(int j = 0; j < _pointCount; j++) // 점 개수만큼 반복
                {
                    // 점 위치 (정규화된 값)
                    Vector2 pos = new Vector2(Mathf.Cos(45 * Mathf.Deg2Rad + Mathf.PI * 2 * j / _pointCount), Mathf.Sin(45 * Mathf.Deg2Rad + Mathf.PI * 2 * j / _pointCount));
                    // 점 위치 (크기 설정)
                    pos *= _size + (0.5f * i);
                    // 점 위치 지정
                    trackLine.SetPosition(j, pos);
                }
            }
        }
    }
}
// 마지막 작성 일자: 2026.10.19