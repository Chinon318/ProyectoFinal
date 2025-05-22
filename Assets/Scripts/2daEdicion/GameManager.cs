using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelPausa;
    public GameObject panelPerder;
    private InfoJugador infoJugador;

    void Awake()
    {
        infoJugador = GameObject.Find("Player").GetComponent<InfoJugador>();
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelPausa != null)
            {
                panelPausa.gameObject.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (infoJugador.isDead)
        {
            Time.timeScale = 0f;
            panelPerder.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void ReanudarJuego()
    {
        panelPausa.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
