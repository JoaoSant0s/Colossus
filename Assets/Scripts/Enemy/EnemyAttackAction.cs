using UnityEngine;
using System.Collections;
using System;

public class EnemyAttackAction : GOAPAction {

    [Header("Attack Action")]
    [SerializeField]
    private float attackDelay = 2;

    private bool attacked = false;
    private float lastSpawnTime;

    public EnemyAttackAction() {
        AddEffect("damagePlayer", true);
        Cost = 60f;
    }

    public override bool CheckProceduralPrecondition(GameObject agent) {
        Target = GameObject.FindGameObjectWithTag("Player");
        return Target != null;
    }

    public override bool IsDone() {
        return attacked;
    }

    public bool AttackDependency() {
        return Target != null && Time.timeSinceLevelLoad > (lastSpawnTime + attackDelay);
    }

    public override bool Perform(GameObject agent) {
        if (AttackDependency()) {
            lastSpawnTime = Time.timeSinceLevelLoad;
            Debug.Log("ATTACK");
            attacked = true;
            return true;
        } else {
            return false;
        }
    }

    public override bool RequiresInRange() {
        return true;
    }

    public override void Reset() {
        attacked = false;
        Target = null;
    }
 
}
