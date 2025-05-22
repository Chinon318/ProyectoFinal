using UnityEngine;

public class EnemyPF : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 movePos;
    private Vector2 targetPos;
    private bool isMoving = false;
    private float stoppingDistance = 0.05f;

    private InfoJugador playerInfo;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInfo = GetComponent<InfoJugador>();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 currentPos = rb.position;

            if (Vector2.Distance(currentPos, targetPos) <= stoppingDistance)
            {
                isMoving = false;
                movePos = Vector2.zero;
            }
            else
            {
                movePos = (targetPos - currentPos).normalized;
                rb.MovePosition(currentPos + movePos * (speed * Time.fixedDeltaTime));
            }

            // Flip del sprite
            if (movePos.x > 0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (movePos.x < -0.1f)
                transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void MoveTo(Vector2 target)
    {
        if (!playerInfo.isDead)
        {
            targetPos = target;
            isMoving = true;
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }

}
