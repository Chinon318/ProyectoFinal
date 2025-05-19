using UnityEngine;

public class EnemyPF : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField]private Rigidbody2D rb;
    private Vector2 movePos;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movePos * (speed * Time.fixedDeltaTime));
    }


    public void MoveTo(Vector2 targetPos)
    {
        movePos = (targetPos - rb.position).normalized;
    }
}
