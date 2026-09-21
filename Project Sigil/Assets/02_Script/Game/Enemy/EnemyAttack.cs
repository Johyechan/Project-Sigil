using UnityEngine;
using System.Collections;

namespace Game.Enemy
{
    // 작성자: 조혜찬
    // 적 공격
    public class EnemyAttack
    {
        private Transform _self; // 적 자기 자신

        MonoBehaviour _behaviour; // Coroutine을 실행하기 위한 객체

        Coroutine _coroutine; // 공격 코루틴을 저장하는 객체

        private float _attackSpeed; // 공격 속도
        private float _attackDistance; // 공격 거리

        private int _damage; // 데미지

        private IHit _hit;

        public EnemyAttack(MonoBehaviour behaviour, Transform self, float attackDistance, float attackSpeed, int damage)
        {
            _behaviour = behaviour;
            _self = self;
            _attackDistance = attackDistance;
            _attackSpeed = attackSpeed;
            _damage = damage;
        }

        // 공격 함수
        public void Attack()
        {
            GameObject core = CheckArea.CheckCircle(_self.position, _attackDistance, Vector2.zero, 0, "Core");
            _hit = core.GetComponent<IHit>();

            _coroutine = _behaviour.StartCoroutine(AttackCo());
        }

        // 공격 정지 함수
        public void AttackStop()
        {
            _behaviour.StopCoroutine(_coroutine);
            _coroutine = null;
        }

        // 공격 코루틴
        private IEnumerator AttackCo()
        {
            while(true)
            {
                yield return new WaitForSeconds(_attackSpeed);
                _hit.OnHit(_damage);
            }
        }
    }
}
// 마지막 작성 일자: 2026.09.18