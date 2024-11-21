using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField]
    private HealthComponent healthComponent;  // Referensi ke komponen kesehatan objek.

    private Collider2D collider;  // Referensi ke Collider2D objek.
    private InvincibilityComponent invincibilityComponent;  // Referensi ke komponen invincibility objek.

    private void Awake()
    {
        collider = GetComponent<Collider2D>();  // Ambil komponen Collider2D objek.
        invincibilityComponent = GetComponent<InvincibilityComponent>();  // Ambil komponen Invincibility.
    }

    public void ApplyDamage(Bullet bullet)
    {
        if (IsInvincible()) return;  // Cek apakah objek dalam keadaan invincible dan lewati jika ya.

        if (healthComponent != null)
        {
            healthComponent.DecreaseHealth(bullet.damage);  // Kurangi kesehatan objek sesuai damage dari peluru.
        }
    }

    public void ApplyDamage(int damageAmount)
    {
        if (IsInvincible()) return;  // Cek apakah objek dalam keadaan invincible dan lewati jika ya.

        if (healthComponent != null)
        {
            healthComponent.DecreaseHealth(damageAmount);  // Kurangi kesehatan objek sesuai damage yang diberikan.
        }
    }

    private bool IsInvincible()
    {
        return invincibilityComponent != null && invincibilityComponent.isInvincible;  // Mengembalikan status invincibility objek.
    }
}
