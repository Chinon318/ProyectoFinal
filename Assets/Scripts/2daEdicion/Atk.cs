using UnityEngine;

public class Atk : MonoBehaviour
{
    [SerializeField]private InfoJugador info;

    void Start()
    {
        info = GetComponentInParent<InfoJugador>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<InfoJugador>().RecibirDmg(info.dmg);
        }
    }

}
