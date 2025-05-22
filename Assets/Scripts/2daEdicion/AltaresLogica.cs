using UnityEngine;

public class AltaresLogica : MonoBehaviour
{
    private ParticleSystem altarParticleSystem;

    private int index;

    private enum Pociones
    {
        bustDmg,
        bustHp
    }

    void Awake()
    {
        altarParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            altarParticleSystem.Stop();
            altarParticleSystem.Clear();

            InfoJugador info = collision.GetComponent<InfoJugador>();
            if (info != null)
            {
                Pociones pocion = (Pociones)index;
                switch (pocion)
                {
                    case Pociones.bustDmg:
                        info.RecibirBoostDmg(5f);
                        break;
                    case Pociones.bustHp:
                        info.RecibirBoostHp(5f);
                        break;
                }
            }
        }
    }
}
