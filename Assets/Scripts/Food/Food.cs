using System;
using System.Collections;
using UnityEngine;

public class Food : MonoBehaviour, ICollectable, IPoolable
{
    [SerializeField] private float _flySpeed = 10;
    private Action _onCollected;

    public void Init(Action onCollected)
    {
        _onCollected = onCollected;
    }

    public void Collect()
    {
        _onCollected?.Invoke();
        BackToPool();
    }

    public void BackToPool()
    {
        FoodPool.Instance.BackObjectToPool(this);
    }

    public void StartFly(Transform head) 
    {
        StartCoroutine(FlyToHeadRoutine(head));
    }

    private IEnumerator FlyToHeadRoutine(Transform head) 
    {
        while (gameObject.activeInHierarchy) 
        {
            transform.position = Vector3.MoveTowards(
                        transform.position,
                        head.transform.position, _flySpeed * Time.deltaTime);

            yield return null; 
        }
    }
}
