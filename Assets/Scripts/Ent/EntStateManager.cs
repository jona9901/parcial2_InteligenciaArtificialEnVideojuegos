using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntStateManager : MonoBehaviour
{
    // Define Ent States
    EntBaseState currentState;
    public EntWanderState wanderState = new EntWanderState();
    public EntSearchWaterState searchState = new EntSearchWaterState();
    public EntMeetingState meetingState = new EntMeetingState();
    public EntFumigateState fumigateState = new EntFumigateState();
    public EntDetectOgreState detectOgreState = new EntDetectOgreState();
    public IrrigateTreeState irrigateState = new IrrigateTreeState();

    // Ent variables
    public bool waterBucket = false;
    public bool isMeeting = false;
    public GameObject pondGO;
    public PondBehaviour pond;
    public Vector3 pondTransform;
    public TreeBehaviour treeToFumigate;
    public TreeBehaviour treeToDrink;
    public TreeBehaviour treeHieve;
    public List<TreeBehaviour> trees;
    public moveVelSimple move;
    public PathFollower pathFollower;
    public float radius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // get pond position
        pondTransform = pondGO.transform.position;

        // add ent to pond ent list
        // pond.GetComponent<PondBehaviour>().ents.Add(this);
        pond = pondGO.GetComponent<PondBehaviour>();
        pond.entsTotal++;

        move = gameObject.GetComponent<moveVelSimple>();
        pathFollower = gameObject.GetComponent<PathFollower>();

        SwitchState(wanderState);
    }

    // Update is called once per frame
    void Update()
    {
        // Meeting
        if (isMeeting)
        {
            // Stop Wandering
            move.OnWander = false;
            move.OnSeek = false;
            SwitchState(meetingState);
        }

        currentState.UpdateState(this);
    }

    public void SwitchState(EntBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ogre")
        {
            SwitchState(detectOgreState);
        }
        currentState.OnCollisionEnter(this, other);
    }
}
