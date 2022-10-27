using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowEatState : CrowBaseState
{

    public GameObject fairy;

    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Persiguiendo Hada");
        crow.move.TargetSeek = fairy;
        crow.move.OnSeek = true;

    }

    public override void UpdateState(CrowStateManager crow)
    {

        Debug.Log("Regresando a la cueva");
        if (crow.hunger > 2)
        {
            crow.move.OnSeek = false;
            crow.SwitchState(crow.restState);
        }
        //Si todavia tiene hambre
        if (crow.hunger <= 2)
        {
            crow.move.OnSeek = false;
            crow.SwitchState(crow.followState);

        }
            
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        FairyStateManager fairy = other.collider.gameObject.GetComponent<FairyStateManager>();
        if(fairy)
        {
            fairy.kill();
        }
    }
}
