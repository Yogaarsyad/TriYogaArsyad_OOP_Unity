using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed = 25f;  // Kecepatan projectile
    public int impactDamage = 12;  // Damage yang diberikan oleh projectile
    private Rigidbody2D rigidbody2D;
    private IObjectPool<Projectile> pool;

    // Menetapkan Object Pool untuk Projectile
    public void InitializePool(IObjectPool<Projectile> projectilePool)
    {
        pool = projectilePool;  // Menyimpan referensi ke pool objek
    }

    // Mengambil komponen Rigidbody2D pada saat objek dibuat
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); // Mengambil referensi Rigidbody2D
    }

    void OnEnable()
    {
        // Menetapkan arah dan kecepatan proyektil setelah diaktifkan
        rigidbody2D.velocity = transform.up * speed;  // Menggerakkan proyektil
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Mengecek apakah objek yang ditabrak adalah player
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Menangani damage yang diberikan pada enemy
            enemy.ReceiveDamage(impactDamage);
        }

        // Mengembalikan proyektil ke pool setelah bertabrakan
        pool?.Release(this);
    }

    void OnBecameInvisible()
    {
        // Mengembalikan proyektil ke pool jika proyektil keluar dari layar
        pool?.Release(this);
    }
}
