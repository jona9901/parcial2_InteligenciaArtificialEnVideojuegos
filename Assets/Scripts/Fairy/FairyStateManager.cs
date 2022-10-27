using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyStateManager : MonoBehaviour
{
     // Define Fairy States
    FairyBaseState currentState;
    public FairySearchWaterState searchWaterState = new FairySearchWaterState();
    public FairyPollinateState pollinateState = new FairyPollinateState();
    public FairyRecolectateState recolectateState = new FairyRecolectateState();
    public FairyEscapreCrowState escapeCrowState = new FairyEscapreCrowState();
    public FairyRest fairyRest = new FairyRest();


    // Fairy variables
    public GameObject pondGO;
    public GameObject fairyObject;
    public PondBehaviour pond;
    public Vector3 pondTransform;
    public float bag;

    public float treePollinization;
    private float deltaPollinization = 2;
    public float thirstyFairy;
    private float deltaThirstyFairy = 2;
    public float collectPollen;
    private float deltaCollectPollinizer = 2;

    //HOW TIRED
    public float stamina;
    private float deltaStamina = 2;

    public moveVelSimple move;



    public TreeBehaviour mainTree;
    public List<TreeBehaviour> trees = new List<TreeBehaviour>();

    public CrowStateManager crow;

    // Start is called before the first frame update
    void Start()
    {
        //RANDOM THIRST
        thirstyFairy = Random.Range(3f, 5f);
        //RANDOM POLLEN
        collectPollen = Random.Range(6f, 8f);

        //HOW TIRED
        stamina = Random.Range(23f, 26f);
        // get pond position
        pondTransform = pondGO.transform.position;
        
        // add ent to pond ent list
        // pond.GetComponent<PondBehaviour>().ents.Add(this);
        pond = pondGO.GetComponent<PondBehaviour>();
        //pond.fairyTotal++;

        move = gameObject.GetComponent<moveVelSimple>();

        move.TargetSeek = pondGO;

        move.OnSeek = true;

        SwitchState(fairyRest);
        
    }

    // Update is called once per frame

    void Update()
    {
        thirstyFairy -= Time.deltaTime / deltaThirstyFairy;
        collectPollen -= Time.deltaTime / deltaCollectPollinizer;
        stamina -= Time.deltaTime / deltaStamina;
        treePollinization -= Time.deltaTime / deltaPollinization;

        if (mainTree.treePollenRemaining < 2)
        {
            SwitchState(pollinateState);
        }

        if (thirstyFairy < 1)
        {
            SwitchState(searchWaterState);
        }

        if(stamina < 20)
        {
            Debug.Log("estoy cansado, ire al arbol");
            SwitchState(fairyRest);
        }

        currentState.UpdateState(this);
    }

    public void SwitchState(FairyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnCollisionEnter(this, other);
    }
    
    public void kill()
    {

        Destroy(gameObject);
    }

    public void escapeCrow(CrowStateManager c)
    {
        move.TargetFlee = c.gameObject;
        crow = c;
        SwitchState(escapeCrowState);
    }

}
