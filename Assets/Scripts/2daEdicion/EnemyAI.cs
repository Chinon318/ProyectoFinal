using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private enum State
    {
        Roaming,
        Following,
    }

    private State state;
    [SerializeField]private EnemyPF enemyPF;

    void Awake()
    {
        enemyPF = GetComponent<EnemyPF>();
        state = State.Roaming;
    }

    private void Start()
    {
        StartCoroutine(RoamingState());
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

    /*IEnumerator FollowingState()
    {
        while (state == State.Following)
        {
            
        }
    }*/

    private Vector2 GetRoamingPosition()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
