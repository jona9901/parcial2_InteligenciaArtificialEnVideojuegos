using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSearchWaterState : CrowBaseState
{
   public override void EnterState(CrowStateManager crow)
    {
        // Search for water
        Debug.Log("Searching for water");
    }

    public override void UpdateState(CrowStateManager crow)
    {
        //Cuando no tiene sed
        if(crow.thirst > 5)
        {
            Debug.Log("Descansa en cueva");
            crow.SwitchState(crow.restState);
        }
            
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collider other)
    {
        Debug.Log("OnCollision");
    }
}
