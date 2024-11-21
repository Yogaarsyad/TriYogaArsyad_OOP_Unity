using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 10; // Menyimpan nilai maksimal kesehatan.

    private int health; // Menyimpan nilai kesehatan saat ini.

    void Awake()
    {
        health = maxHealth; // Menginisialisasi kesehatan dengan nilai maksimal saat objek dibuat.
    }

    public void Subtract(int amount)
    {
        health -= amount; // Mengurangi kesehatan sesuai jumlah yang diberikan.

        if (health <= 0) // Mengecek apakah kesehatan sudah habis.
        {
            Destroy(gameObject); // Menghancurkan objek jika kesehatan habis.
        }
    }

    public int GetHealth()
    {
        return health; // Mengembalikan nilai kesehatan saat ini.
    }
}
