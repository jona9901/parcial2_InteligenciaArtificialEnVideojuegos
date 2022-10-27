using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFollowState : CrowBaseState
{

    public GameObject[] forest;
    public GameObject currentForest;

    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Buscando Hada");
        int m = Random.Range(0, forest.Length);
        currentForest = forest[m];

        crow.move.TargetSeek = currentForest;
        crow.move.OnSeek = true;

        
    }

    public override void UpdateState(CrowStateManager crow)
    {
        float distanceC2F = Vector3.Distance(crow.gameObject.transform.position, currentForest.transform.position);  

        if (distanceC2F <= 5)
        {
            crow.move.OnSeek = false;
            crow.move.OnWander = true;
        }

        Debug.Log("Comer Hada");
        if(crow.fairyFound == true)
        {
            crow.SwitchState(crow.eatState);
        }

    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        
    }
}
