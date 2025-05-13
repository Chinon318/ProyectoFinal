using UnityEngine;

public class Atk_Player : MonoBehaviour
{
    private InfoJugador info;

    [Header("Config bullet")]
    public GameObject bulletPrefab;
    public Transform spawnBullet;

    private float bulletSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Disparo();
    }


    private void Disparo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab, spawnBullet);
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

            bulletRB.AddForce( Vector2.right, ForceMode2D.Impulse );

        }
    }
}
