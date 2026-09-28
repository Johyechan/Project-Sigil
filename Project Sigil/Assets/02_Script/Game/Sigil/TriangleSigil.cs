using Game.Bullet;
using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Util.Pool;

namespace Game.Sigil
{
    // 작성자: 조혜찬
    // 삼각형 문양
    public class TriangleSigil : ISigil
    {
        public IEnumerator DrawSigil(SigilScriptableObject sigilData, Transform parent)
        {
            TriangleSigilScriptableObject data = sigilData as TriangleSigilScriptableObject;

            // 양쪽 끝 총알
            GameObject lastBullet1 = null;
            GameObject lastBullet2 = null;

            // 생성한 총알들을 담을 임시 부모 객체
            GameObject tempBulletParent = new GameObject("temp");
            // 총알들의 부모 객체의 위치를 플레이어의 위치와 동기화
            tempBulletParent.transform.position = parent.transform.position;
            // 회전 값을 0으로 초기화
            tempBulletParent.transform.rotation = Quaternion.identity;

            // 밑 변 그리기(오른쪽 방향, 왼쪽 방향으로 각각 하나 씩 총 data.UnderBulletCount * 2개)
            for (int i = 0; i < data.UnderBulletCount; i++)
            {
                // 첫 시작만 두 개의 시작 총알의 간격을 data.UnderBulletInterval로 하기 위해서 원래 간격의 절반으로 하기
                // 이후에는 
                // 현재 반복 수 * 기존 간격 + 첫 총알의 위치(즉 처음 위치로 할당했던 data.UnderBulletInterval / 2)
                // 로 간격을 설정하여 일정한 간격 유지
                float interval = i == 0 ? data.UnderBulletInterval / 2 : i * data.UnderBulletInterval + data.UnderBulletInterval / 2;
                // 왼쪽 총알 생성
                GameObject bullet1 = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
                bullet1.transform.position = parent.transform.position + new Vector3(-interval, data.UnderLineY);
                bullet1.transform.SetParent(tempBulletParent.transform, true);
                bullet1.SetActive(true);
                // 오른쪽 총알 생성
                GameObject bullet2 = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
                bullet2.transform.position = parent.transform.position + new Vector3(interval, data.UnderLineY);
                bullet2.transform.SetParent(tempBulletParent.transform, true);
                bullet2.SetActive(true);

                // 대기
                yield return new WaitForSeconds(data.Delay);

                // 만약 마지막 생성일 경우
                if(i == data.UnderBulletCount - 1)
                {
                    // 양 끝 총알 저장
                    lastBullet1 = bullet1;
                    lastBullet2 = bullet2;
                }
            }

            // 양 끝 총알을 시작점으로 할당
            Vector3 start1 = lastBullet1.transform.position;
            Vector3 start2 = lastBullet2.transform.position;
            // 마지막 남은 위 꼭짓점을 끝점으로 할당
            Vector3 end = parent.transform.position + new Vector3(0, data.TopDotY);

            // 나머지 변을 채울 총알 수 만큼 반복
            for (int i = 1; i < data.SideBulletCount; i++)
            {
                // 총알 개수에 따른 총알 간의 일정한 간격을 확보
                float t = i / (float)data.SideBulletCount;
                // 총알 위치 저장
                Vector3 pos1 = Vector3.Lerp(start1, end, t);
                Vector3 pos2 = Vector3.Lerp(start2, end, t);

                // 총알 생성
                GameObject bullet1 = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
                bullet1.transform.position = pos1;
                bullet1.transform.SetParent(tempBulletParent.transform, true);
                bullet1.SetActive(true);

                // 총알 생성
                GameObject bullet2 = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
                bullet2.transform.position = pos2;
                bullet2.transform.SetParent(tempBulletParent.transform, true);
                bullet2.SetActive(true);

                yield return new WaitForSeconds(data.Delay);
            }

            // 꼭짓점 역할을 할 총알 생성
            GameObject bullet = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
            bullet.transform.position = end;
            bullet.transform.SetParent(tempBulletParent.transform);
            bullet.SetActive(true);

            // 플레이어를 기준으로 적 탐색
            GameObject[] enemys = CheckArea.CheckObjectsInCircle(parent.transform.position, float.MaxValue, Vector2.zero, 0, "Enemy");
            // 플레이어와 떨어진 거리(최소의 거리를 구하기 위해 초기 값을 최대로 지정)
            float distance = float.MaxValue;
            // 현재 가장 가까운 적을 저장하는 변수
            GameObject target = null;
            // 적들 순회
            for(int i = 0; i < enemys.Length; i++)
            {
                // 총알의 맨 위 꼭짓점과 적의 거리를 측정
                float betweenDistance = Vector3.Distance(bullet.transform.position, enemys[i].transform.position);
                // 이전에 저장된 거리보다 현재 거리가 더 짧다면
                if(distance > betweenDistance)
                {
                    // 최소 거리 저장
                    distance = betweenDistance;
                    // 최소 거리의 적 저장
                    target = enemys[i];
                }
            }

            // 대기
            yield return new WaitForSeconds(data.Delay);

            // 삼각형을 그리는 총알들의 부모에서 가장 가까운 적까지 가는 방향 벡터 값 구하기
            Vector3 dir = target.transform.position - tempBulletParent.transform.position;
            // 적이 있는 방향의 각도 구하기
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            // 삼각형을 그리는 총알들의 부모 회전
            tempBulletParent.transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

            // 대기
            yield return new WaitForSeconds(data.Delay);

            // 총알이 나가는 위치
            Vector3 fireBulletCreatePos = bullet.transform.position;

            // 삼각형을 그리고 있는 총알의 개수만큼 반복
            for(int i = tempBulletParent.transform.childCount - 1; i >= 0; i--)
            {
                // 발사용 총알 생성 후 발사
                GameObject b = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
                b.transform.position = fireBulletCreatePos;
                b.SetActive(true);
                
                BulletBase bulletBase = b.GetComponent<BulletBase>();

                // 목표 방향을 기준으로 랜덤 각도 생성
                float randomAngle = Random.Range(angle - data.SectorFormRange, angle + data.SectorFormRange);

                // 라디안 변환
                float radian = randomAngle * Mathf.Deg2Rad;

                // 랜덤 발사 방향 계산
                Vector3 fireDir = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian));

                bulletBase.Fire(fireDir, data.BulletSpeed);

                // 밑 변부터 지우기
                GameObject child = tempBulletParent.transform.GetChild(0).gameObject;
                ObjectPool.Instance.ReturnObject(PoolType.NormalBullet, child);

                yield return new WaitForSeconds(data.Delay);
            }
        }
    }
}
// 마지막 작성 일자: 2026.09.28