using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowFollowState : CrowBaseState
{
    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Buscando Hada");
        
    }

    public override void UpdateState(CrowStateManager crow)
    {
        Debug.Log("Comer Hada");
        if(crow.fairyFound == true)
        {

            crow.SwitchState(crow.eatState);

        }

    }

    public override void OnCollisionEnter(CrowStateManager crow, Collider other)
    {
        
    }
}
