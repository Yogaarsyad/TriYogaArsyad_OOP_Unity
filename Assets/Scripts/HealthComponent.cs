using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int maximumHealth = 10;  // Nilai maksimal kesehatan.

    private int currentHealth;  // Nilai kesehatan saat ini.

    private void Awake()
    {
        currentHealth = maximumHealth;  // Inisialisasi kesehatan dengan nilai maksimal.
    }

    // Mengurangi kesehatan dengan jumlah tertentu
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;  // Mengurangi kesehatan dengan jumlah yang diberikan.

        if (currentHealth <= 0)  // Cek apakah kesehatan habis.
        {
            HandleDeath();  // Panggil metode untuk menangani objek yang mati.
        }
    }

    // Mengembalikan nilai kesehatan saat ini
    public int GetCurrentHealth()
    {
        return currentHealth;  // Mengembalikan nilai kesehatan saat ini.
    }

    // Menangani aksi yang terjadi saat objek mati
    private void HandleDeath()
    {
        Destroy(gameObject);  // Hancurkan objek saat kesehatan habis.
    }
}
