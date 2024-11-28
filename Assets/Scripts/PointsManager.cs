using UnityEngine;
using TMPro;

// Mengelola poin, wave, dan jumlah musuh
public class PointsManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText, waveText, enemiesText; // Referensi UI
    private int points = 0, wave = 1, enemiesLeft = 0; // Data internal

    public void AddPoints(int enemyLevel, int count) // Tambah poin
    {
        points += enemyLevel * count;
        pointsText.text = "Points: " + points; // Update UI
    }

    public void UpdateWave(int currentWave, int enemies) // Perbarui wave
    {
        wave = currentWave;
        enemiesLeft = enemies;
        waveText.text = "Wave: " + wave;
        enemiesText.text = "Enemies: " + enemiesLeft;
    }

    public void EnemyDefeated() // Kurangi jumlah musuh
    {
        enemiesLeft--;
        enemiesText.text = "Enemies: " + enemiesLeft; // Update UI
    }
}
