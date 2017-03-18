using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMotor : MonoBehaviour {

    [Header("Movement properties")]
    [SerializeField]
    private float movementSpeed;

    Rigidbody body;
    NavMeshAgent pathFinder;

    float smoothDirection;
    float smoothDirectionVelocity;

    void Start() {
        pathFinder = GetComponent<NavMeshAgent>();

        body = GetComponent<Rigidbody>();
    }

    public void Move(GameObject target) {
        pathFinder.SetDestination(target.transform.position);     
    }

    public void Stop() {
        pathFinder.ResetPath();
    }


        
}
