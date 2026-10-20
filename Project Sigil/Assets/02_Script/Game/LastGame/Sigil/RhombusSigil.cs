using System.Collections;
using UnityEngine;
using Util.Pool;
using System.Collections.Generic;
using Game.Bullet;

namespace Game.Sigil
{
    // 작성자: 조혜찬
    // 마름모 문양
    public class RhombusSigil : ISigil
    {
        public IEnumerator DrawSigil(SigilScriptableObject sigilData, Transform parent)
        {
            RhombusSigilScriptableObject data = sigilData as RhombusSigilScriptableObject;

            // 총알들을 저장하는 임시 객체
            GameObject tempBulletParent = new GameObject("temp");
            tempBulletParent.transform.position = parent.position;

            // 위에 있는 슬래시 형태의 변 시작점
            Vector3 topToLeftStartPos = data.TopToLeftStartPos;
            // 위에 있는 슬래시 형태의 변 끝점
            Vector3 topToLeftEndPos = data.TopToLeftEndPos;

            // 아래 있는 백 슬래시 형태의 변 시작점
            Vector3 leftToBottomStartPos = data.LeftToBottomStartPos;
            // 아래 있는 백 슬래시 형태의 변 끝점
            Vector3 leftToBottomEndPos = data.LeftToBottomEndPos;

            // 아래 있는 슬래시 형태의 변 시작점
            Vector3 bottomToRightStartPos = data.BottomToRightStartPos;
            // 아래 있는 슬래시 형태의 변 끝점
            Vector3 bottomToRightEndPos = data.BottomToRightEndPos;

            // 위에 있는 백 슬래시 형태의 변 시작점
            Vector3 rightToTopStartPos = data.RightToTopStartPos;
            // 위에 있는 백 슬래시 형태의 변 끝점
            Vector3 rightToTopEndPos = data.RightToTopEndPos;

            Stack<GameObject> topToLeftBullets = new Stack<GameObject>();
            Stack<GameObject> leftToBottomBullets = new Stack<GameObject>();
            Stack<GameObject> bottomToRightBullets = new Stack<GameObject>();
            Stack<GameObject> rightToTopBullets = new Stack<GameObject>();

            for (int i = 0; i < data.LineBulletCount; i++)
            {
                // Lerp에 사용할 0~1 사이의 비율을 구하기 위해 현재 총알 순서를 최대 총알 수로 나눔
                float t = i / (float)data.LineBulletCount;

                // 위에 있는 슬래시 형태의 변을 그리기 위한 총알 생성 후 스택에 저장
                topToLeftBullets.Push(CreateBullet(topToLeftStartPos, topToLeftEndPos, t, parent, tempBulletParent.transform, PoolType.NormalBullet));
                // 아래에 있는 백 슬래시 형태의 변을 그리기 위한 총알 생성 후 스택에 저장
                leftToBottomBullets.Push(CreateBullet(leftToBottomStartPos, leftToBottomEndPos, t, parent, tempBulletParent.transform, PoolType.NormalBullet));
                //  아래에 있는 슬래시 형태의 변을 그리기 위한 총알 생성 후 스택에 저장
                bottomToRightBullets.Push(CreateBullet(bottomToRightStartPos, bottomToRightEndPos, t, parent, tempBulletParent.transform, PoolType.NormalBullet));
                // 위에 있는 백 슬래시 형태의 변을 그리기 위한 총알 생성 후 스택에 저장
                rightToTopBullets.Push(CreateBullet(rightToTopStartPos, rightToTopEndPos, t, parent, tempBulletParent.transform, PoolType.NormalBullet));

                yield return new WaitForSeconds(data.Delay);
            }

            for(int i = 0; i < data.LineBulletCount; i++)
            {
                FireBullet(topToLeftBullets.Pop(), parent, data.BulletSpeed);
                FireBullet(leftToBottomBullets.Pop(), parent, data.BulletSpeed);
                FireBullet(bottomToRightBullets.Pop(), parent, data.BulletSpeed);
                FireBullet(rightToTopBullets.Pop(), parent, data.BulletSpeed);

                yield return new WaitForSeconds(data.Delay);
            }
        }

        // 총알 생성 함수
        private GameObject CreateBullet(Vector3 startPos, Vector3 endPos, float t, Transform player, Transform bulletParent, PoolType type)
        {
            // 플레이어 위치를 기준으로 시작점과 끝점 사이의 t 비율에 해당하는 위치를 구해 총알 위치로 설정
            Vector3 pos = player.position + Vector3.Lerp(startPos, endPos, t);

            GameObject bullet = ObjectPool.Instance.GetObject(type);
            bullet.transform.position = pos;
            bullet.transform.SetParent(bulletParent, true);
            bullet.SetActive(true);

            return bullet;
        }

        // 총알 발사 함수
        private void FireBullet(GameObject bullet, Transform player, float speed)
        {
            // 발사 방향
            Vector3 fireDirection = (bullet.transform.position - player.position).normalized;

            BulletBase bulletBase = bullet.GetComponent<BulletBase>();
            // 총알 발사
            bulletBase.Fire(fireDirection, speed);
        }
    }
}
// 마지막 작성 일자: 2026.10.07