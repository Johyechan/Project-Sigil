using Game.Sigil;
using System.Collections;
using UnityEngine;

namespace Game.Player
{
    // 작성자: 조혜찬
    // 적 공격
    public class PlayerAttack
    {
        // 공격 중인지 여부
        public bool IsAttacking { get => _isAttacking; }
        private bool _isAttacking;

        // 현재 문양
        private ISigil _currentSigil; 
        // 원 문양
        private ISigil _circleSigil;
        // 삼각형 문양
        private ISigil _triangleSigil;

        // 현재 문양 데이터
        private SigilScriptableObject _currentSigilData;
        // 원 문양 데이터
        private CircleSigilScriptableObject _circleSigilData;
        // 삼각형 문양 데이터
        private TriangleSigilScriptableObject _triangleSigilData;

        // 플레이어 자기 자신
        private Transform _self;

        public PlayerAttack(CircleSigilScriptableObject circleSigilData, TriangleSigilScriptableObject triangleSigilData, Transform self)
        {
            _circleSigilData = circleSigilData;
            _triangleSigilData = triangleSigilData;
            _self = self;
        }

        // 초기화
        public void Init()
        {
            _circleSigil = new CircleSigil();
            _triangleSigil = new TriangleSigil();
            _isAttacking = false;
        }

        public void Attack(SigilType type)
        {
            _isAttacking = true;
            switch(type)
            {
                case SigilType.Circle:
                    _currentSigil = _circleSigil;
                    _currentSigilData = _circleSigilData;
                    break;
                case SigilType.Triangle:
                    _currentSigil = _triangleSigil;
                    _currentSigilData = _triangleSigilData;
                    break;
            }
        }

        public IEnumerator DrawSigil(MonoBehaviour behaviour)
        {
            yield return behaviour.StartCoroutine(_currentSigil.DrawSigil(_currentSigilData, _self));

            _isAttacking = false;
        }
    }
}
// 마지막 작성 일자: 2026.09.28