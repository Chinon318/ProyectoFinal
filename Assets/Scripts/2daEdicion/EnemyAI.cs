using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Roaming,
        Following,
        Atk
    }

    [Header("Animator")]
    [SerializeField] private Animator animator;
    private State state;

    [Header("Configuraciones")]
    [SerializeField] private EnemyPF enemyPF;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 1f; // Nueva distancia para atacar

    

    private Coroutine currentStateCoroutine;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        enemyPF = GetComponent<EnemyPF>();
        state = State.Roaming;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        currentStateCoroutine = StartCoroutine(RoamingState());
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer < attackRange && state != State.Atk)
        {
            ChangeState(State.Atk);
        }
        else if (distanceToPlayer < detectionRange && distanceToPlayer >= attackRange && state != State.Following)
        {
            ChangeState(State.Following);
        }
        else if (distanceToPlayer >= detectionRange && state != State.Roaming)
        {
            ChangeState(State.Roaming);
        }

        animator.SetBool("1_Move", enemyPF.IsMoving());
    }

    private void ChangeState(State newState)
    {
        if (currentStateCoroutine != null)
        {
            StopCoroutine(currentStateCoroutine);
        }

        state = newState;

        switch (state)
        {
            case State.Roaming:
                currentStateCoroutine = StartCoroutine(RoamingState());
                break;
            case State.Following:
                currentStateCoroutine = StartCoroutine(FollowingState());
                break;
            case State.Atk:
                currentStateCoroutine = StartCoroutine(AttackState());
                break;
        }
    }

    IEnumerator RoamingState()
    {
        while (state == State.Roaming)
        {
            Vector2 roamPos = GetRoamingPosition();
            enemyPF.MoveTo(roamPos);
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator FollowingState()
    {
        while (state == State.Following)
        {
            enemyPF.MoveTo(playerTransform.position);
            yield return null;
        }
    }

    IEnumerator AttackState()
    {
        while (state == State.Atk)
        {
            Debug.Log("Atacando");
            animator.SetTrigger("2_Attack");
            enemyPF.MoveTo(transform.position);
            yield return new WaitForSeconds(1f);
        }
    }

    private Vector2 GetRoamingPosition()
    {
        return (Vector2)transform.position + new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
