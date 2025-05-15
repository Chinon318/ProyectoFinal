using UnityEngine;

public class Atk_Player : MonoBehaviour
{
    [SerializeField]private Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Ataque();
    }

    private void Ataque()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("2_Attack");
        }
    }
}
