using TMPro;
using UnityEngine;

public class InfoCanvas : MonoBehaviour
{
    [SerializeField]private InfoJugador playerInfo;
    [SerializeField]private TMP_Text txt_hp;
    [SerializeField]private TMP_Text txt_shield;

    void Awake()
    {
        playerInfo = GameObject.Find("Player").GetComponent<InfoJugador>();
        txt_hp = GameObject.Find("num_Hp").GetComponent<TMP_Text>();
        txt_shield = GameObject.Find("num_Shield").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (playerInfo != null)
        {
            txt_hp.text = playerInfo.hp.ToString("F0");
            txt_shield.text = playerInfo.shield.ToString("F0");
        }
    }
}
