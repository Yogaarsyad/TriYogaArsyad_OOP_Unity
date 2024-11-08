
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform parentTransform;  // Menyimpan transformasi parent dari weapon
    public int damage = 10;            // Menyimpan nilai damage senjata
    public float range = 5.0f;         // Menyimpan jangkauan senjata
    public float fireRate = 1.0f;      // Kecepatan tembakan senjata
    public bool isEquipped = false;    // Menyimpan status apakah senjata sudah dipakai atau belum
}

using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder; // Tempat untuk menampung weapon yang bisa di-pick up.
    private Weapon weapon; // Weapon yang akan dipegang oleh player setelah pickup.

    private void Start()
    {
        // Menginisialisasi objek weapon dari weaponHolder.
        weapon = weaponHolder;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Memeriksa jika objek yang menabrak memiliki tag "Player".
        if (collision.CompareTag("Player"))
        {
            // Memberikan weapon kepada player.
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.PickupWeapon(weapon);
            }

            // Hapus WeaponPickup setelah diambil.
            Destroy(gameObject);
        }
    }
}


