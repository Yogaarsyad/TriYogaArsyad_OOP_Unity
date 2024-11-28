using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 10;

    private int health;

    void Awake()
    {
        health = maxHealth;
    }

    public void Subtract(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetHealth()
    {
        return health;
    }
}
