using System;
using System.Collections;
using UnityEngine;

public class InfoJugador : MonoBehaviour
{
    public Stats playerStats;

    public float hp;
    public float dmg;
    public float shield;

    private Animator animator;

    public bool isDead;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();

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
            isDead = true;
            StartCoroutine(Morir());
        }
    }


    public void RecibirBoostDmg(float cantidad)
    {
        dmg += dmg*(cantidad/100);
    }

    public void RecibirBoostHp(float cantidad)
    {
        hp += hp * (cantidad / 100);
    }

    IEnumerator Morir()
    {
        animator.SetBool("isDeath", isDead);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
