using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowEatState : CrowBaseState
{

    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Persiguiendo Hada");
    }

    public override void UpdateState(CrowStateManager crow)
    {

        Debug.Log("Regresando a la cueva");
        if (crow.hunger > 2)
        {
            crow.SwitchState(crow.restState);
        }
        //Si todavia tiene hambre
        if (crow.hunger <= 2)
        {
            crow.SwitchState(crow.followState);

        }
            
    }

    public override void OnCollisionEnter(CrowStateManager crow, Collider other)
    {
        FairyStateManager fairy = other.GetComponent<Collider>().gameObject.GetComponent<FairyStateManager>();
        if(fairy)
        {
            fairy.kill();
        }
    }
}
