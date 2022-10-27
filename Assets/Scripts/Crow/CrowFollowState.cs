using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFollowState : CrowBaseState
{

    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Buscando Hada");
        int m = Random.Range(0, crow.forest.Count);
        crow.currentForest = crow.forest[m].gameObject;

        crow.move.TargetSeek = crow.currentForest;
        crow.move.OnSeek = true;

        
    }

    public override void UpdateState(CrowStateManager crow)
    {
        float distanceC2F = Vector3.Distance(crow.gameObject.transform.position, crow.currentForest.transform.position);  

        if (distanceC2F <= 5)
        {
            crow.move.OnSeek = false;
            crow.move.OnWander = true;
        }

        Debug.Log("Comer Hada");
        if(crow.fairyFound = true)
        {
            crow.SwitchState(crow.eatState);
        }

    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        
    }
}
