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

        private GameObject ResetObject(GameObject obj)
        {
            obj.transform.position = Vector3.zero;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.parent = transform;
            obj.SetActive(false);
            return obj;
        }

        private GameObject CreateObject(PoolType type)
        {
            GameObject obj = Instantiate(_poolMap[type].obj, transform);
            return ResetObject(obj);
        }

        // 풀 객체 꺼내기 함수
        public GameObject GetObject(PoolType type, Transform parent = null)
        {
            if (_pool[type].Count > 0)
            {
                GameObject obj = _pool[type].Dequeue();
                obj.transform.parent = parent;
                return obj;
            }
            else
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
// 마지막 작성 일자: 2026.09.21