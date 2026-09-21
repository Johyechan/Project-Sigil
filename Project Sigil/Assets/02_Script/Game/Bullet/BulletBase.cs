using System.Collections;
using UnityEngine;
using Util.Pool;

namespace Game.Bullet
{
    // 작성자: 조혜찬
    // 총알 부모 클래스
    public abstract class BulletBase : MonoBehaviour
    {
        [SerializeField] protected BulletScriptableObject _data;

        private Coroutine _fireCo; // 발사 코루틴
        private Coroutine _lifeTimeCo; // 생명 시간 코루틴

        protected virtual void OnDisable()
        {
            // 발사 및 생명 시간 코루틴이 null이 아닐 때 정지

            if(_fireCo != null)
            {
                StopCoroutine(_fireCo);
            }

            if(_lifeTimeCo != null)
            {
                StopCoroutine(_lifeTimeCo);
            }
        }

        // 총알 발사 함수
        public void Fire(Vector3 direction, float speed)
        {
            _fireCo = StartCoroutine(FireCo(direction, speed));
            _lifeTimeCo = StartCoroutine(LifeTimeCo());
        }

        // 총알 발사 코루틴
        protected abstract IEnumerator FireCo(Vector3 direction, float speed);

        // 총알 생존 시간 코루틴
        private IEnumerator LifeTimeCo()
        {
            yield return new WaitForSeconds(_data.LifeTime);

            ObjectPool.Instance.ReturnObject(_data.Type, gameObject);
        }

        // 적과 부딪쳤을 때 실행 함수
        protected abstract void OnTriggerEnter2D(Collider2D collision);
    }
}
// 마지막 작성 일자: 2026.09.21