using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Util.Pool;

namespace Game.Manager
{
    // 작성자: 조혜찬
    // 웨이브 관리자
    public class WaveManager : MonoBehaviour
    {
        // 코어 객체
        [SerializeField] private Transform _core;

        // 코어로부터 떨어진 거리
        [SerializeField] private float _distance;
        // 적 생성 지연 시간
        [SerializeField] private float _createDelay;
        // 웨이브 휴식 시간
        [SerializeField] private float _restTime;

        // 첫 웨이브에 생성되는 적 수
        [SerializeField] private int _createEnemyCount;
        // 웨이브마다 상승하는 적 수
        [SerializeField] private int _waveIncreaseValue;

        private void Start()
        {
            StartCoroutine(WaveCo());
        }

        // 웨이브 코루틴
        private IEnumerator WaveCo()
        {
            while(true)
            {
                // 현재 생성한 적 수
                int currentCreateEnemyCount = 0; 
                while (currentCreateEnemyCount <= _createEnemyCount)
                {
                    // 랜덤한 각도 생성
                    float angle = Random.Range(0f, 361f);

                    // cos, sin 함수는 라디안 값을 원하기 때문에 디그리 값을 라디안 값으로 변경
                    float radian = angle * Mathf.Deg2Rad;

                    Vector3 createPos = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian)) * _distance; // 랜덤한 각도 * 멀어져야하는 거리

                    GameObject enemy = ObjectPool.Instance.GetObject(PoolType.SquareEnemy, transform); // 적 생성
                    enemy.transform.position = _core.position + createPos; // 코어 위치를 기준으로 적 생성 위치로 이동
                    enemy.SetActive(true); // 적 활성화
                    yield return new WaitForSeconds(_createDelay);
                    currentCreateEnemyCount++;
                }
                // 이번 웨이브에 생성한 적들이 전부 죽을 때까지 대기
                yield return new WaitUntil(() => transform.childCount == 0);
                _createEnemyCount += _waveIncreaseValue; // 웨이브에 등장하는 적 수 증가
                yield return new WaitForSeconds(_restTime); // 휴식
            }
        }
    }
}
// 마지막 작성 일자: 2026.10.09