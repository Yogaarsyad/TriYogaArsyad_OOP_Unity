using UnityEngine;
using TMPro;

// Mengelola kesehatan Player
public class HealthManager : MonoBehaviour
{
    public TextMeshProUGUI healthText; // Referensi UI
    private int health = 100; // Nilai awal kesehatan

    public void TakeDamage(int damage) // Kurangi kesehatan
    {
        health = Mathf.Max(0, health - damage); // Pastikan tidak negatif
        healthText.text = "Health: " + health; // Update UI
    }
}
