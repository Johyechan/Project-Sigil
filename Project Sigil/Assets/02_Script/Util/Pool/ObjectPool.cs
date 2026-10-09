using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Util.Pool
{
    // 작성자: 조혜찬
    // 오브젝트 풀
    public class ObjectPool : MonoBehaviour
    {
        // 외부에서 접근 가능한 인스턴스
        public static ObjectPool Instance { get; private set; }

        [SerializeField] private List<PoolData> _poolDataList;

        private Dictionary<PoolType, PoolData> _poolMap = new Dictionary<PoolType, PoolData>();
        private Dictionary<PoolType, Queue<GameObject>> _pool = new Dictionary<PoolType, Queue<GameObject>>();

        private void Awake()
        {
            Instance = this;
            Init();
        }

        private void OnDestroy()
        {
            if(Instance == this)
                Instance = null;
        }

        private void Init()
        {
            foreach(var poolData in _poolDataList)
            {
                PoolType type = poolData.type;

                if (!_poolMap.ContainsKey(type))
                {
                    _poolMap.Add(type, poolData);
                }
            }

            foreach(var pool in _poolMap)
            {
                PoolType type = pool.Key;
                GameObject obj = pool.Value.obj;

                if(!_pool.ContainsKey(type))
                {
                    _pool.Add(type, new Queue<GameObject>());
                }
                for(int i = 0; i < pool.Value.count; i++)
                {
                    _pool[type].Enqueue(CreateObject(type));
                }
            }
        }

        // 객체 초기화 함수
        private GameObject ResetObject(GameObject obj)
        {
            obj.SetActive(false); // 객체 비활성화
            obj.transform.position = Vector3.zero; // 객체 위치 (0, 0, 0)으로 초기화
            obj.transform.rotation = Quaternion.identity; // 회전 값을 (0, 0, 0, 1)으로 초기화
            obj.transform.SetParent(transform); // 현재 스크립트를 가지는 객체를 부모로 지정
            return obj;
        }

        // 객체 생성
        private GameObject CreateObject(PoolType type)
        {
            GameObject obj = Instantiate(_poolMap[type].obj, transform);
            return ResetObject(obj);
        }

        // 풀 객체 꺼내기 함수
        public GameObject GetObject(PoolType type, Transform parent = null)
        {
            // type 풀에 객체가 있을 경우
            if (_pool[type].Count > 0)
            {
                GameObject obj = _pool[type].Dequeue();
                obj.transform.parent = parent;
                return obj;
            }
            else // type 풀에 객체가 없을 경우
            {
                GameObject obj = CreateObject(type);
                obj.transform.parent = parent;
                return obj;
            }
        }

        // 풀 객체 반환 함수
        public void ReturnObject(PoolType type, GameObject obj)
        {
            _pool[type].Enqueue(ResetObject(obj));
        }
    }
}
// 마지막 작성 일자: 2026.10.09