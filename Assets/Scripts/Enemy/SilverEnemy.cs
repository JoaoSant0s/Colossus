using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SilverEnemy : Enemy {

    public override HashSet<KeyValuePair<string, object>> createGoalState() {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
        goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
        goal.Add(new KeyValuePair<string, object>("stayAlive", true));
        return goal;
    }

    public override bool moveAgent(GOAPAction nextAction) {
        float dist = Vector3.Distance(transform.position, nextAction.Target.transform.position);

        if (dist <= nextAction.ActionDistance()) {
            Motor.Stop();
            nextAction.SetInRange(true);
            return true;
        } else  if ( dist < nextAction.MovementDistance() ) {
            Motor.Move(nextAction.Target);    
        }

        return false;        
    }
}
