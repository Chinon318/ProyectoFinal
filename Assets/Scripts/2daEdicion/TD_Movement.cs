using UnityEngine;

public class TD_Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;

    //Animator
    private Animator anim;

    [Header("Configuracion booleans")]
    [SerializeField]private bool isMoving;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Movimiento();
    }


    private void Movimiento()
    {
        float horMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        if (horMovement != 0 || verMovement != 0)
        {
            Vector2 direccion = new Vector2(horMovement,verMovement).normalized;

            rb.MovePosition(rb.position + direccion * (speed * Time.fixedDeltaTime));

            isMoving = true;

            anim.SetBool("1_Move", isMoving);
        }
        else
        {
            isMoving = false;
            anim.SetBool("1_Move", isMoving);
        }

        if (horMovement < -0.1f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if (horMovement > 0.1f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }

}
