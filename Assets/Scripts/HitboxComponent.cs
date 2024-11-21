using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField]
    HealthComponent health; // Referensi ke komponen kesehatan yang akan dikurangi.

    Collider2D area; // Referensi ke Collider2D yang ada pada objek.

    private InvincibilityComponent invincibilityComponent; // Referensi ke komponen invincibility.

    void Start()
    {
        area = GetComponent<Collider2D>(); // Mengambil komponen Collider2D pada objek.
        invincibilityComponent = GetComponent<InvincibilityComponent>(); // Mengambil komponen Invincibility.
    }

    public void Damage(Bullet bullet)
    {
        if (invincibilityComponent != null && invincibilityComponent.isInvincible) return; // Mengabaikan damage jika objek dalam status invincible.

        if (health != null)
            health.Subtract(bullet.damage); // Mengurangi kesehatan objek sesuai damage dari peluru.
    }

    public void Damage(int damage)
    {
        if (invincibilityComponent != null && invincibilityComponent.isInvincible) return; // Mengabaikan damage jika objek dalam status invincible.

        if (health != null)
            health.Subtract(damage); // Mengurangi kesehatan objek sesuai damage yang diberikan.
    }
}
