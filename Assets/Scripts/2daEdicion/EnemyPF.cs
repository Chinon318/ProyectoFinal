using UnityEngine;

public class EnemyPF : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField] private Rigidbody2D rb;
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

    public void DistanceTo(Vector2 targetPos)
    {
        float distance = Vector2.Distance(rb.position, targetPos);
        if (distance < 0.1f)
        {
            movePos = Vector2.zero;
        }
        else
        {
            movePos = (targetPos - rb.position).normalized;
        }
    }
}
