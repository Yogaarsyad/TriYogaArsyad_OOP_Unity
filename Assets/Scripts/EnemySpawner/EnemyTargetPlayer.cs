using UnityEngine;

public class EnemyTargetPlayer : Enemy
{
    public float speed = 2f;

    private Transform player;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        PickRandomPositions();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x);

            rb.rotation = angle;
            rb.velocity = speed * Time.deltaTime * direction;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void PickRandomPositions()
    {
        Vector2 randPos;
        Vector2 dir;

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
