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


    public bool haskey;

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
            if (cantidad <= shield)
            {
                shield -= cantidad;
            }
            else
            {
                float sobra = cantidad - shield;
                shield = 0;
                hp -= sobra;
            }
        }
        else
        {
            hp -= cantidad;
        }

        if (hp <= 0 && !isDead)
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

    public void RecibirBoostShield(float cantidad)
    {
        if (shield > 0)
        {
            shield += shield * (cantidad / 100);
        }
        else
        {
            shield += cantidad;
        }
    }

    IEnumerator Morir()
    {
        animator.SetBool("isDeath", isDead);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
