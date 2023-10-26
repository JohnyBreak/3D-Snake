using UnityEngine;

public class FoodFlyActivator : SnakeHeadCollisionChecker
{
    [SerializeField] private Transform _headTransform;
    protected override void DoOnCollisionEnter(Collision collision)
    {
        // fly food to head
        if (collision.transform.TryGetComponent(out Food food))
        {
            food.StartFly(_headTransform);
        }
    }
}
