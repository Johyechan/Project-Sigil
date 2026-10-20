using Game.Bullet;
using System.Collections;
using UnityEngine;
using Util.Pool;

namespace Game.Sigil
{
    // 작성자: 조혜찬
    // 사각형 문양
    public class SquareSigil : ISigil
    {
        public IEnumerator DrawSigil(SigilScriptableObject sigilData, Transform parent)
        {
            SquareSigilScriptableObject data = sigilData as SquareSigilScriptableObject;

            // 시작 위치
            Vector3 startPos = Vector3.zero;
            // 끝 위치
            Vector3 endPos = Vector3.zero;

            for(int i = 0; i < 4; i++)
            {
                // i가 사각형의 4개 변 중 현재 어떤 변을 생성할지 나타낸다
                // 그래서 각 변마다 시작점과 끝점을 새롭게 정해줘야 함
                switch (i)
                {
                    case 0:
                        startPos = data.BottomStartPos;
                        endPos = data.BottomEndPos;
                        break;
                    case 1:
                        startPos = data.LeftStartPos;
                        endPos = data.LeftEndPos;
                        break;
                    case 2:
                        startPos = data.TopStartPos;
                        endPos = data.TopEndPos;
                        break;
                    case 3:
                        startPos = data.RightStartPos;
                        endPos = data.RightEndPos;
                        break;
                }
                // j를 1부터 시작하는 이유는 Lerp의 t = 0과 t = 1에서 꼭짓점이 중복되기때문에
                for (int j = 1; j <= data.LineBulletCount; j++)
                {
                    // Lerp에 사용할 0~1 사이의 비율을 구하기 위해 현재 총알 순서를 최대 총알 수로 나눔
                    float t = j / (float)data.LineBulletCount;
                    // 플레이어 위치를 기준으로 시작점과 끝점 사이의 t 비율에 해당하는 위치를 구해 총알 위치로 설정
                    Vector3 pos = parent.position + Vector3.Lerp(startPos, endPos, t);

                    GameObject bullet = ObjectPool.Instance.GetObject(PoolType.NormalBullet, parent);
                    bullet.transform.position = pos;
                    bullet.SetActive(true);

                    yield return new WaitForSeconds(data.Delay);
                }
            }

            for(int i = 0; i < parent.childCount; i++)
            {
                BulletBase bullet = parent.GetChild(i).GetComponent<BulletBase>(); // 플레이어 자식으로 있는 총알 가져오기
                bullet.Fire(Vector3.zero, 0);
            }
        }
    }
}
// 마지막 작성 일자: 2026.10.09