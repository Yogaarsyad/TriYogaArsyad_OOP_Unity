using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;  // Menyimpan objek weapon sebagai serialized field.
    private Weapon weapon;  // Menyimpan objek weapon dari weaponHolder.

    private void Awake()
    {
        // Menginisialisasi weapon dengan weaponHolder saat objek dibuat.
        weapon = weaponHolder;
    }

    private void Start()
    {
        // Jika weapon tidak null, inisialisasi method terkait sebagai false atau kondisi awal..
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika collider mengenai objek player.
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                // Pindahkan weapon ke player dan set transform parent dari weapon.
                weapon.transform.parent = player.transform;
                player.PickupWeapon(weapon);

                // Aktifkan visual weapon di player.
                TurnVisual(true);
                Destroy(gameObject);  // Hapus objek pickup setelah diambil.
            }
        }
    }

    // Method untuk mengaktifkan atau menonaktifkan komponen visual weapon.
    private void TurnVisual(bool state)
    {
        // Polymorphism: 2 bentuk.
        weapon.gameObject.SetActive(state);  // Bentuk pertama: mengaktifkan objek GameObject.
        
        // Bentuk kedua: mengaktifkan semua komponen yang ada di dalam weapon.
        foreach (var component in weapon.GetComponentsInChildren<Renderer>())
        {
            component.enabled = state;
        }
    }
}
