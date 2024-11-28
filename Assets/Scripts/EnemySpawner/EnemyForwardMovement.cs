using UnityEngine;

public class EnemyForwardMovement : Enemy
{
    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        PickRandomPositions();
    }

    private void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.up);

        if (Camera.main.WorldToViewportPoint(new(transform.position.x, transform.position.y, transform.position.z)).y < -0.05f)
        {
            PickRandomPositions();
        }
    }

    private void PickRandomPositions()
    {
        Vector2 randPos = new(Random.Range(0.1f, 0.99f), 1.1f);

        transform.position = Camera.main.ViewportToWorldPoint(randPos) + new Vector3(0, 0, 10);
    }
}
