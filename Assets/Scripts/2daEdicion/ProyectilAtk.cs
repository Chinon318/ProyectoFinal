using System.Collections;
using UnityEngine;

public class ProyectilAtk : MonoBehaviour
{
    public GameObject proyectilPrefab;
    public Transform spawnPoint;
    public float speed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(TiempoEsperaProyectil(0.15f));
        }
    }


    private IEnumerator TiempoEsperaProyectil(float tiempoEspera)
    {
        yield return new WaitForSeconds(tiempoEspera);
        LanzarProyectil();
    }

    private void LanzarProyectil()
    {
        GameObject proyectil = Instantiate(proyectilPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();

        rb.linearVelocity = spawnPoint.up * speed;

        Destroy(proyectil, 2f);
    }
}
