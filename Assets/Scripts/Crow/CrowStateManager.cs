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
    public GameObject cave;
    public GameObject fairy;
    //public GameObject[] forest;
    public GameObject currentForest;
    public PondBehaviour pond;
    public Vector3 pondTransform;
    public bool fairyFound = false;
    public float hunger = 10.0f;
    public float thirst = 10.0f;
    public float deltaHunger = 1.0f;
    public float deltaThirst = 2.0f;    
    public moveVelSimple move;
    public List<GameObject> forest;
    public GameObject player;


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
        SwitchState(restState);
        
    }

    // Update is called once per frame
    void Update()
    {
        hunger -= Time.deltaTime / deltaHunger;
        thirst -= Time.deltaTime / deltaThirst;

        move.OnSeek = false;

        float distance2player = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (distance2player <= 5.0f)
        {
            move.TargetSeek = player;
            move.OnSeek = true;
            if (distance2player < 1.5f)
            {
                //Robar bolsa
                Debug.Log("robar bolsa polen");
                move.OnSeek = false;
            }
        }

        currentState.UpdateState(this);
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

    public void kill()
    {
        Destroy(this);
    }

    
}
