using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyStateManager : MonoBehaviour
{
     // Define Fairy States
    FairyBaseState currentState;
    public FairyWanderState wanderState = new FairyWanderState();
    public FairySearchWaterState searchWaterState = new FairySearchWaterState();
    public FairyPollinateState pollinateState = new FairyPollinateState();
    public FairyRecolectateState recolectateState = new FairyRecolectateState();
    public FairyFleesState fleeState = new FairyFleesState();
    public FairyRest fairyRest = new FairyRest();


    // Fairy variables
    public GameObject pondGO;
    public GameObject fairyObject;
    public PondBehaviour pond;
    public Vector3 pondTransform;
    public float bag;

    public float treePollinization = 10;
    public float deltaPollinization = 2;
    public float thirstyFairy = 20;
    public float deltaThirstyFairy = 2;
    public float collectPollen = 30;
    public float deltaCollectPollinizer = 2;



    public TreeBehaviour mainTree;
    public List<TreeBehaviour> trees = new List<TreeBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        // get pond position
        pondTransform = pondGO.transform.position;

        // add ent to pond ent list
        // pond.GetComponent<PondBehaviour>().ents.Add(this);
        pond = pondGO.GetComponent<PondBehaviour>();
        //pond.fairyTotal++;

        SwitchState(wanderState);
    }

    // Update is called once per frame
    void Update()
    {
        treePollinization -= Time.deltaTime / deltaPollinization;
        thirstyFairy -= Time.deltaTime / deltaThirstyFairy;
        collectPollen -= Time.deltaTime / deltaCollectPollinizer;
    }

    public void SwitchState(FairyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        // currentState.OnCollisionEnter(this, other);
    }
    public void kill()
    {

        Destroy(gameObject);
    }
}
