using UnityEngine;

public class CrowRestState : CrowBaseState
{
    
    
    public override void EnterState(CrowStateManager crow)
    {
        Debug.Log("Resting in cave");        
    }

    public override void UpdateState(CrowStateManager crow)
    {

        if(crow.hunger <= 2)
        {
            Debug.Log("I'm hungry");
            crow.SwitchState(crow.eatState);
        } 
        if(crow.thirst <= 5)
        {
            Debug.Log("I'm thirsty");
            crow.SwitchState(crow.searchState);
        }

    }

    public override void OnCollisionEnter(CrowStateManager crow, Collision other)
    {

    }
}
