using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioEscenas : MonoBehaviour
{
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }
}
