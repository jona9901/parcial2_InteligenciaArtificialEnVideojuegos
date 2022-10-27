using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSearchWaterState : CrowBaseState
{

   public override void EnterState(CrowStateManager crow)
    {
        // Search for water
        Debug.Log("Searching for water");

        crow.move.TargetSeek = crow.pondGO;
        crow.move.OnSeek = true;

    }

    public override void UpdateState(CrowStateManager crow)
    {
        //Cuando no tiene sed

        float distance = Vector3.Distance(crow.gameObject.transform.position, crow.pondGO.transform.position);
        if (distance < 1.5)
        {
            crow.thirst += 20.0f;
            crow.move.OnSeek = false;
            Debug.Log("Hada Muerta");
            //crow.fairy.kill();
        }
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
