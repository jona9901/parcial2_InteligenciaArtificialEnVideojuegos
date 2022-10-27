using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSearchWaterState : CrowBaseState
{

    public GameObject pondGO;

   public override void EnterState(CrowStateManager crow)
    {
        // Search for water
        Debug.Log("Searching for water");

        crow.move.TargetSeek = pondGO;
        crow.move.OnSeek = true;

    }

    public override void UpdateState(CrowStateManager crow)
    {
        //Cuando no tiene sed
        if(crow.thirst > 5)
        {
            Debug.Log("Descansa en cueva");
            crow.move.OnSeek = false;
            crow.SwitchState(crow.restState);
        }
            
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        Debug.Log("OnCollision");
    }
}
