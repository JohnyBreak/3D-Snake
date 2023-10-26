using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnHelperTransform;
    [SerializeField] private Transform _apple;
    [SerializeField] private Food _food;
    [SerializeField] private LayerMask _appleMask;

    [SerializeField] private int _startFoodAmount = 10;

    private float _radius;

    private void Start()
    {
        _radius = (_apple.transform.position - _spawnHelperTransform.position).magnitude;

        for (int i = 0; i < _startFoodAmount; i++)
        {
            SpawnFood();
        }
    }


    private void SpawnFood()
    {
        Vector3 rayPoint = transform.position + Random.onUnitSphere * _radius;

        RaycastHit hit;
        Physics.Raycast(rayPoint,  _apple.transform.position - rayPoint, out hit, _radius, _appleMask);

        Food food = FoodPool.Instance.GetPooledObject();//Instantiate(_food, hit.point + hit.normal * 0.5f, Quaternion.identity);
        food.transform.position = hit.point + hit.normal * 0.5f;

        food.Init(this.OnFoodCollected);
        
        food.gameObject.SetActive(true);
        food.transform.parent = this.transform;
    }

    private void OnFoodCollected() 
    {
        SpawnFood();
    }

}
