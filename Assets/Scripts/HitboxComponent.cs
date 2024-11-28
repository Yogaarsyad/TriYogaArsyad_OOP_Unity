using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField]
    HealthComponent health;

    Collider2D area;

    private InvincibilityComponent invincibilityComponent;

    public UnityEvent OnHitboxCollide;


    void Start()
    {
        area = GetComponent<Collider2D>();
        invincibilityComponent = GetComponent<InvincibilityComponent>();
        OnHitboxCollide = new UnityEvent();
    }

    public void Damage(Bullet bullet)
    {
        if (invincibilityComponent != null && invincibilityComponent.isInvincible) return;

        if (health != null)
        {
            health.Subtract(bullet.damage);
            OnHitboxCollide.Invoke();
        }
    }

    public void Damage(int damage)
    {
        if (invincibilityComponent != null && invincibilityComponent.isInvincible) return;

        if (health != null)
        {
            health.Subtract(damage);
            OnHitboxCollide.Invoke();
        }
    }
}
