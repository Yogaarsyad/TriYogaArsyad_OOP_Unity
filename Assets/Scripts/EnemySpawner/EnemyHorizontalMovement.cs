using UnityEngine;

public class EnemyHorizontalMovement : Enemy
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 dir;

    private void Awake()
    {
        PickRandomPositions();
    }

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * dir);

        Vector3 ePos = Camera.main.WorldToViewportPoint(new(transform.position.x, transform.position.y, transform.position.z));

        if (ePos.x < -0.05f && dir == Vector2.right)
        {
            PickRandomPositions();
        }
        if (ePos.x > 1.05f && dir == Vector2.left)
        {
            PickRandomPositions();
        }
    }

    private void PickRandomPositions()
    {
        Vector2 randPos;

        if (Random.Range(-1, 1) >= 0)
        {
            dir = Vector2.right;
        }
        else
        {
            dir = Vector2.left;
        }

        if (dir == Vector2.right)
        {
            randPos = new(1.1f, Random.Range(0.1f, 0.95f));
        }
        else
        {
            randPos = new(-0.01f, Random.Range(0.1f, 0.95f));
        }

        transform.position = Camera.main.ViewportToWorldPoint(randPos) + new Vector3(0, 0, 10);
    }
}
