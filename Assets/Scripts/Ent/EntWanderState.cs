using UnityEngine;

public class EntWanderState : EntBaseState
{
    TreeBehaviour currentTree;
    
    public override void EnterState(EntStateManager ent)
    {
        ent.move.OnSeek = false;
        // Call for wander code
        Debug.Log("Wander");
        ent.move.OnWander = true;
    }

    public override void UpdateState(EntStateManager ent)
    {
        Debug.Log("Update");
        float distance = Vector3.Distance(ent.treeHieve.gameObject.transform.position, ent.gameObject.transform.position);

        /*
        // return the ent to the 
        if (Vector3.Distance(ent.treeHieve.gameObject.transform.position, ent.gameObject.transform.position) >= ent.radius)
        {
            ent.move.OnWander = false;
            ent.move.TargetSeek = ent.treeHieve.gameObject;
            ent.move.OnSeek = true;
        } else
        {
            ent.move.OnSeek = false;
            ent.move.OnWander = true;
        }
        */
        for (int i = 0; i < ent.trees.Count; i++)
        {
            currentTree = ent.trees[i];
            if (currentTree.isPlage) // detect if a tree is thirsty
            {
                ent.move.OnWander = false;
                ent.treeToFumigate = currentTree;
                ent.SwitchState(ent.fumigateState);
            } else if (currentTree.isThirsty) // detect if a tree is thirsty
            {
                ent.move.OnWander = false;
                ent.treeToDrink = currentTree;
                ent.SwitchState(ent.searchState);
            }
        }
        

    }

    public override void OnCollisionEnter(EntStateManager ent, Collider other)
    {
        
    }
}
