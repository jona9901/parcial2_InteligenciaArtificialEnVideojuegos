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
        Debug.Log("UpdateState");
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {
        Debug.Log("OnCollision");
    }
}
