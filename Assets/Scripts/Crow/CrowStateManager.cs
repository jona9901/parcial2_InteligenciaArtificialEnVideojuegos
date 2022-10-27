using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowStateManager : MonoBehaviour
{
     // Define Crow States
    CrowBaseState currentState;
    
    public CrowSearchWaterState searchState = new CrowSearchWaterState(); //bebe-estanque
    public CrowEatState eatState = new CrowEatState(); //comer-hada
    public CrowFollowState followState = new CrowFollowState(); //busca-hada
    public CrowRestState restState = new CrowRestState(); //descansa-cueva

    // Crow variables
    public GameObject pondGO;
    public PondBehaviour pond;
    public Vector3 pondTransform;
    public List<TreeBehaviour> trees = new List<TreeBehaviour>();
    public bool fairyFound = false;
    public float hunger = 10;
    public float thirst = 10;
    public float deltaHunger = 1;
    public float deltaThirst = 2;    
    public moveVelSimple move;

    // Start is called before the first frame update
    void Start()
    {
        move = gameObject.GetComponent<moveVelSimple>();
        // get pond position
        pondTransform = pondGO.transform.position;
        // add ent to pond ent list
        // pond.GetComponent<PondBehaviour>().ents.Add(this);
        pond = pondGO.GetComponent<PondBehaviour>();
        //pond.crowTotal++;
        
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= Time.deltaTime / deltaHunger;
        thirst -= Time.deltaTime / deltaThirst;

    }

    public void SwitchState(CrowBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        // currentState.OnCollisionEnter(this, other);
    }

    
}
