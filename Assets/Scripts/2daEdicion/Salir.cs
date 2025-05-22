using UnityEngine;

public class Salir : MonoBehaviour
{
    public GameObject panelGanador;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InfoJugador info = collision.GetComponent<InfoJugador>();
            if (info.haskey)
            {
                Time.timeScale = 0f;
                panelGanador.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
