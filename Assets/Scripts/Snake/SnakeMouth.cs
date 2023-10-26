using UnityEngine;

public class SnakeMouth : SnakeHeadCollisionChecker
{
    [SerializeField] private SnakeBody _snakeBody;

    protected override void DoOnCollisionEnter(Collision collision)
    {
        // grow snake
        _snakeBody.GrowSnake();

        // collect food
        if (collision.transform.TryGetComponent(out ICollectable collectable))
        {
            collectable.Collect();
        }
    }
}
