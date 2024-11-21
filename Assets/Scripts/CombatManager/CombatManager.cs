using UnityEngine;

public class WaveController : MonoBehaviour
{
    // Daftar spawner musuh untuk setiap lokasi spawn
    public EnemySpawner[] spawnLocations;
    // Variabel untuk menghitung waktu antar gelombang
    private float elapsedTime = 0f;
    // Interval waktu antara gelombang musuh
    [SerializeField] private float spawnInterval = 4f;
    // Nomor gelombang yang sedang berjalan
    public int currentWave = 1;
    // Jumlah total musuh yang sudah di-spawn
    public int enemiesSpawned = 0;

    void Update()
    {
        // Menambahkan waktu yang sudah berlalu pada elapsedTime
        elapsedTime += Time.deltaTime;

        // Mengecek jika waktu sudah melebihi spawnInterval
        if (elapsedTime >= spawnInterval)
        {
            // Memanggil metode SpawnEnemy() pada setiap spawner untuk spawn musuh
            foreach (var spawner in spawnLocations)
            {
                spawner.SpawnEnemy();
            }
            
            // Menambah nomor gelombang dan reset elapsedTime
            currentWave++;
            elapsedTime = 0;
        }
    }
}
