using System.Collections;
using UnityEngine;

public class AltaresLogica : MonoBehaviour
{
    private ParticleSystem altarParticleSystem;

    [SerializeField] private int index;

    [SerializeField] private float boostPorcentaje = 5f;
    [SerializeField] private float tiempoDeActivacion = 10f;

    [SerializeField]private GameObject panelBuffDmg;

    private bool isActive;

    private enum Pociones
    {
        bustDmg,
        bustHp,
        bustShield
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
            isActive = false;

            InfoJugador info = collision.GetComponent<InfoJugador>();
            if (info != null)
            {
                Pociones pocion = (Pociones)index;
                switch (pocion)
                {
                    case Pociones.bustDmg:
                        info.RecibirBoostDmg(boostPorcentaje);
                        StartCoroutine(PanelRutina(1.5f));
                        break;
                    case Pociones.bustHp:
                        info.RecibirBoostHp(boostPorcentaje);
                        break;
                    case Pociones.bustShield:
                        info.RecibirBoostShield(boostPorcentaje);
                        break;
                }
            }

            if (!isActive)
            {
                StartCoroutine(ActivarAltar());
            }
        }
    }


    IEnumerator ActivarAltar()
    {
        yield return new WaitForSeconds(tiempoDeActivacion);
        isActive = true;
        altarParticleSystem.Play();
    }

    IEnumerator PanelRutina(float tiempo)
    {
        panelBuffDmg.SetActive(true);
        yield return new WaitForSeconds(tiempo);
        panelBuffDmg.SetActive(false);
    }
}
