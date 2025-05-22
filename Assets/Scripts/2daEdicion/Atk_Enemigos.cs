using UnityEngine;

public class Atk_Enemigos : MonoBehaviour
{
    [SerializeField]private InfoJugador info;

    void Start()
    {
        info = GetComponentInParent<InfoJugador>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<InfoJugador>().RecibirDmg(info.dmg);
        }
    }
}
