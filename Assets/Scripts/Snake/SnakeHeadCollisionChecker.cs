using UnityEngine;

public abstract class SnakeHeadCollisionChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionMask;

    protected void OnCollisionEnter(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & _collisionMask) != 0)
        {
            DoOnCollisionEnter(collision);
            return;
        }
    }

    protected abstract void DoOnCollisionEnter(Collision collision);
}
