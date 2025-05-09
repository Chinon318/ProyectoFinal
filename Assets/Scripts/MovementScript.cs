using System.Collections;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;


    [SerializeField] private float speed;
    private Vector2 perroZero = Vector2.zero;

    [SerializeField] private float jumpForce = 5f;


    //Salto coyote
    [SerializeField]private float coyoteTime = 0.2f;
    [SerializeField]private float coyoteTimerCount;

    //Guardar salto
    [SerializeField] private float jumpBuffer = 0.2f;
    [SerializeField]private float jumpBufferCount;


    private bool hasJumped;


    private GroundDetect detector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        detector = GetComponentInChildren<GroundDetect>();
    }


    void Update()
    {
        Movimiento();
        ControlBufferSalto();
        Saltar();
    }


    private void Movimiento()
    {
        float horMovement = Input.GetAxis("Horizontal");

        if (horMovement != 0)
        {
            Vector2 direccion = new Vector2(horMovement, 0).normalized;
            rb.linearVelocityX = direccion.x * speed;

            Debug.Log("Moviendo");
        }
        else
        {
            rb.linearVelocityX = perroZero.x;
        }
    }

    private void Saltar()
    {
        if (detector.isGrounded)
        {
            coyoteTimerCount = coyoteTime;
            hasJumped = false;
        }
        else
        {
            coyoteTimerCount -= Time.deltaTime;
        }

        
        if (jumpBufferCount > 0 && !hasJumped && (detector.isGrounded || coyoteTimerCount > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX,0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Saltando");
            hasJumped = true;
            coyoteTimerCount = 0;
            StartCoroutine(EsperarBuffer(0.15f));
        }
    }


    private void ControlBufferSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBufferCount = jumpBuffer;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }
    }

    IEnumerator EsperarBuffer(float time)
    {
        yield return new WaitForSeconds(time);
        jumpBufferCount = 0;
    }
}
