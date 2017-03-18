using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour, IGOAP {

    private EnemyMotor motor;

    protected float minDist = 11f;
    protected float aggroDist = 5f;

    public abstract bool moveAgent(GOAPAction nextAction);

    public abstract HashSet<KeyValuePair<string, object>> createGoalState();

    void Start() {
        motor = GetComponent<EnemyMotor>();
    }

    public EnemyMotor Motor {
        get { return motor; }
    }

    public HashSet<KeyValuePair<string, object>> getWorldState() {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();
        worldData.Add(new KeyValuePair<string, object>("damagePlayer", false)); //to-do: change player's state for world data here
        worldData.Add(new KeyValuePair<string, object>("evadePlayer", false));
        return worldData;
    }

    public void actionsFinished() {
    }

    public void planAborted(GOAPAction aborter) {
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal) {
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GOAPAction> actions) {
    }
}
