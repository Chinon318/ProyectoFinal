using UnityEngine;

public class RecogerObjetos : MonoBehaviour
{
    private InfoJugador infoJugador;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            infoJugador = collision.GetComponent<InfoJugador>();

            infoJugador.haskey = true;
            Debug.Log("Recogido");
            Destroy(gameObject);
        }
    }
}
