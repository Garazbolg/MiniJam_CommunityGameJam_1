using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    Queue<GameObject> pool;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int poolSize;

    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.position = this.transform.position;
        pool.Enqueue(gameObject);
    }

    private void FillPool(){
        while (pool.Count < poolSize)
        {
            GameObject thing = Instantiate<GameObject>(prefabs[Random.Range(0, prefabs.Length)], this.transform);
            thing.SetActive(false);
            SendToPool sendToPool = thing.GetComponent<SendToPool>();
            if (sendToPool)
            {
                sendToPool.pool = this;
            }
            pool.Enqueue(thing);
        }
    }

    private void Awake() {
        pool = new Queue<GameObject>();
        FillPool();
    }

    public GameObject Get(){
        if(pool.Count <= 0){
            FillPool();
        }
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public GameObject Get(Vector3 position, Quaternion rotation, Transform parent)
    {
        if (pool.Count <= 0)
        {
            FillPool();
        }
        GameObject obj = pool.Dequeue();
        obj.transform.SetPositionAndRotation(position, rotation);
        obj.transform.parent = parent;
        return obj;
    }
}
