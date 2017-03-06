using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMotor : MonoBehaviour {

    [SerializeField]
    private float distancePlayer = 10.0f;
    [SerializeField]
    private float attackDistancePlayer = 2.0f;
    [SerializeField]
    private float waitMovementTime = 1f;

    NavMeshAgent pathFinder;
    Transform player;
    private bool waitMovement;

    void Start() {
        pathFinder = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitMovement = false;
    }

    IEnumerator WalkControll() {
        waitMovement = true;
        yield return new WaitForSeconds(waitMovementTime);
        waitMovement = false;
    }   

    void FixedUpdate() {
        var targetDistance = Vector3.Distance(player.position, transform.position);        
        
        if (targetDistance < attackDistancePlayer) {
            pathFinder.ResetPath();            
        } else if(targetDistance < distancePlayer && !waitMovement) {
            pathFinder.SetDestination(player.position);
            StartCoroutine(WalkControll());
        }
    }
}
