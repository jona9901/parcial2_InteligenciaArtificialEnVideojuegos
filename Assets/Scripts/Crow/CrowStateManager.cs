using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowStateManager : MonoBehaviour
{
     // Define Crow States
    CrowBaseState currentState;
    public CrowWanderState wanderState = new CrowWanderState();
    public CrowSearchWaterState searchState = new CrowSearchWaterState();
    public CrowDetectFairyState detectFairyState = new CrowDetectFairyState();
    public CrowEatState eatState = new CrowEatState();
    public CrowFollowState followState = new CrowFollowState();

    // Crow variables
    public GameObject pondGO;
    public PondBehaviour pond;
    public Vector3 pondTransform;
    public List<TreeBehaviour> trees = new List<TreeBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        // get pond position
        pondTransform = pondGO.transform.position;

        // add ent to pond ent list
        // pond.GetComponent<PondBehaviour>().ents.Add(this);
        pond = pondGO.GetComponent<PondBehaviour>();
        //pond.crowTotal++;

        SwitchState(wanderState);
    }

    // Update is called once per frame
    void Update()
    {
        
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
