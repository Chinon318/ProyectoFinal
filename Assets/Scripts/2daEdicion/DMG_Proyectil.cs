using UnityEngine;

public class DMG_Proyectil : MonoBehaviour
{
    [SerializeField] private float damage = 5f;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            InfoJugador infoEnemigo = collision.GetComponent<InfoJugador>();
            if (infoEnemigo != null)
            {
                infoEnemigo.RecibirDmg(damage);
                Destroy(gameObject); 
            }
        }
    }
}
