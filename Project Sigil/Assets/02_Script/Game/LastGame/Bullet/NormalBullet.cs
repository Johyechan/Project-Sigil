using Game.Enemy;
using System.Collections;
using UnityEngine;
using Util.Pool;

namespace Game.Bullet
{
    // 작성자: 조혜찬
    // 일반 총알
    public class NormalBullet : BulletBase
{
        protected override IEnumerator FireCo(Vector3 direction, float speed)
        {
            while(true)
            {
                transform.position += direction * speed * Time.deltaTime;
                yield return null;
            }
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent(out EnemyController enemyController))
            {
                IHit hit = enemyController.GetComponent<IHit>();
                hit.OnHit(_data.Damage);
                ObjectPool.Instance.ReturnObject(_data.Type, gameObject);
            }
        }
    }
}
// 마지막 작성 일자: 2026.09.21