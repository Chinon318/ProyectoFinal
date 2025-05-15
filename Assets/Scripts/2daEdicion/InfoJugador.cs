using System;
using UnityEngine;

public class InfoJugador : MonoBehaviour
{
    public Stats playerStats;

    public float hp;
    public float dmg;
    public float shield;

    void Awake()
    {
        hp = playerStats.hp;
        dmg = playerStats.dmg;
        shield = playerStats.shield;
    }


    public void RecibirDmg(float cantidad)
    {
        if (shield > 0)
        {
            shield -= cantidad;
            Debug.Log("Daño recibido");
        }
        else
        {
            hp -= cantidad;
            Debug.Log("Daño recibido");
        }


        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
