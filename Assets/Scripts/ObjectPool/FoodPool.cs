using UnityEngine;

public class FoodPool : BaseObjectPool<Food>
{
    protected override Food CreateNewObject()
    {
        Food obj = Instantiate(_objectPrefab, transform.position, Quaternion.identity);

        BackObjectToPool(obj);
        _pooledObjects.Add(obj);
        return obj;
    }
}
