using UnityEngine;

public class InfoJugador : MonoBehaviour
{
    public Stats playerStats;

    [SerializeField]private float hp;
    [SerializeField]private float dmg;
    [SerializeField]private float shield;

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
        }
        else
        {
            hp -= cantidad;
        }


        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
