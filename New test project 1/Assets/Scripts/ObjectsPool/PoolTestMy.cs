using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[System.Serializable]
public class PoolTestMy<T> where T : MonoBehaviour 
{
    public ObjectPool<T> pool;

    public T prefab;
    public Transform pointPosition;
    public Transform container;

    public T _system;

    public T CreateObject()
    {
        var createObject = UnityEngine.Object.Instantiate(prefab, pointPosition.position, pointPosition.rotation, container);

        if (createObject.TryGetComponent(out IPoolable<T> pool))
            pool.SetPool(this.pool);

        return createObject;
    }

    public void OnTakeObjectFromPool(T obj)
    {
        obj.transform.position = pointPosition.position;
        obj.transform.right = pointPosition.right;

        obj.gameObject.SetActive(true);
    }

    public void OnReturnObjectToPull(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    public void OnDestroyObject(T obj)
    {
        Object.Destroy(obj.gameObject);
    }
}
