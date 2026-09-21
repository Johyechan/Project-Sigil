using Game.Bullet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util.Pool;

namespace Game.Sigil
{
    // 작성자: 조혜찬
    // 원 문양
    public class CircleSigil : ISigil
    {
        public IEnumerator DrawSigil(SigilScriptableObject sigilData, Transform parent)
        {
            CircleSigilScriptableObject data = sigilData as CircleSigilScriptableObject;

            Dictionary<GameObject, Vector2> directionMap = new Dictionary<GameObject, Vector2>(); // 총알과 날아갈 방향을 함께 저장하는 딕셔너리

            // 총알 수 만큼 반복
            for (int i = 0; i < data.BulletCount; i++)
            {
                // 총알 풀에서 꺼내기
                GameObject bullet = ObjectPool.Instance.GetObject(PoolType.NormalBullet);
                // x 좌표
                float x = Mathf.Cos(Mathf.PI * 2 * i / data.BulletCount);
                // y 좌표
                float y = Mathf.Sin(Mathf.PI * 2 * i / data.BulletCount);
                // 총알이 날아가는 방향을 저장
                Vector3 direction = new Vector3(x, y);
                // 최종 위치 = (x, y) 원점으로부터 radius만큼 떨어지기
                bullet.transform.position = parent.position + direction * data.Radius;
                // 총알 활성화
                bullet.SetActive(true);
                directionMap.Add(bullet, direction);
                // 대기
                yield return new WaitForSeconds(data.Delay);
            }

            foreach(var bullet in directionMap)
            {
                BulletBase bulletBase = bullet.Key.GetComponent<BulletBase>();
                Vector3 direction = bullet.Value;
                bulletBase.Fire(direction, data.BulletSpeed);
            }

            yield return null;
        }
    }
}
// 마지막 작성 일자: 2026.09.21