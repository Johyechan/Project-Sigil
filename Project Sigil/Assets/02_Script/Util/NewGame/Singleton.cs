using UnityEngine;

namespace Util.Singleton
{
    // 작성자: 조혜찬
    // 싱글톤 부모 클래스
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance { get => _instance; }

        private void Awake()
        {
            if(_instance != null && _instance != this)  // 이미 같은 인스턴스가 있다면
            {
                Destroy(this);                          // 자기 자신 삭제
            }
            else                                        // 같은 인스턴스가 없다면
            {
                _instance = this as T;                  // 인스턴스 할당
                DontDestroyOnLoad(gameObject);      // 씬 변경 시에도 파괴되지 않도록 설정
            }
        }
    }
}
// 마지막 작성 일자: 2026.11.16