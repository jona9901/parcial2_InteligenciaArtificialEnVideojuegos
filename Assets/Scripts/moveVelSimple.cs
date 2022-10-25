using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVelSimple : MonoBehaviour {
    private SphereCollider sphereCollider;

    // general data
    public Vector3 vc_Velocity;
    public Vector3 vc_Heading;
    Vector3 vn_Velocity;
    public float s_rotSpeed=20.0f;

    public float s_MaxSpeed=10.0f;
    public float s_MinSpeed = 1.0f;

    public float jitter = 1.5f;
    public float wanderRadius = 1.5f;
    public float wanderDistance = 1.5f;
    public float pfRadius = 1.5f;
    public float oaRadius = 1.5f;
    private Vector3 targetWander;

    private Vector3 newPosition;

    public GameObject TargetSeek;
    public GameObject TargetFlee;
    public GameObject TargetPursuit;
    public GameObject path;

  
    public bool OnSeek = false;
    public bool OnFlee = false;
    public bool OnWander = false;
    public bool OnPursuit = false;
    public bool OnObstacleAvoidance = false;

    public float s_panicDist;

    public List<GameObject> obstacles;
    public GameObject targetAvoidance;
    public float avoidanceRadius = 1.5f;

   

    // Use this for initialization
    void Start () {
       // s_MaxSpeed = 8.0f;
        s_MinSpeed = 0.2f;
        s_panicDist = 30.0f;
        vn_Velocity = new Vector3(0.0f, 0.0f, 0.0f);
        vc_Velocity = new Vector3(0.0f, 0.0f, 0.0f);
      
        targetWander = Vector3.Normalize(Vector3.forward) * wanderRadius;

        sphereCollider = GetComponent<SphereCollider>();
    }
	
	// Update is called once per frame
	void Update () {        
        vn_Velocity = Vector3.zero;

        if (OnSeek )
        { if (Vector3.Distance(TargetSeek.transform.position, transform.position) > 1.0)
                vn_Velocity = vn_Velocity + Seek(TargetSeek.transform.position);
            else
                //vn_Velocity = Vector3.zero;
                vn_Velocity = vc_Velocity * -1.0f;
        }

        if (OnFlee)
        {
            vn_Velocity = vn_Velocity + Flee(TargetFlee.transform.position);
        }

        if (OnPursuit)
        {
            vn_Velocity = vn_Velocity + Pursuit(TargetPursuit);
        }

        if (OnWander)
        {
            vn_Velocity = vn_Velocity + Wander();
        }

        if (OnObstacleAvoidance)
        {
            vn_Velocity = vn_Velocity + ObstacleAvoidance();
            //vn_Velocity = vn_Velocity + Wander();
        }
                
        //**********************************************************

        vc_Velocity += vn_Velocity;
        vc_Velocity = Vector3.ClampMagnitude(vc_Velocity, s_MaxSpeed);
        newPosition = transform.position + (vc_Velocity * Time.deltaTime);

        if(vc_Velocity.magnitude>s_MinSpeed)
             transform.position = newPosition;
       
        // update the direction of the boid
        vc_Heading = vc_Velocity.normalized;

        //****************************************

        float angle = Vector3.SignedAngle(transform.forward, vc_Heading, Vector3.up);
        //Debug.Log(angle);
        float rotAngle = 0.0f;

        if (angle < -0.1f)
            rotAngle = Time.deltaTime * -1.0f * s_rotSpeed;
        if (angle > 0.1f)
            rotAngle = Time.deltaTime * s_rotSpeed;
        if (angle >= -0.1f && angle <= 0.1f)
        {
            if (Vector3.Dot(transform.forward, vc_Heading) >= 0.9)
                rotAngle = 0.0f;
            if (Vector3.Dot(transform.forward, vc_Heading) <= -0.9)
                rotAngle = 10.0f;
        }

        //Debug.Log("rotAngle" + rotAngle);
        transform.Rotate(0.0f, rotAngle, 0.0f, Space.Self);
        //*****************************************

    


    }
    //******************************************************************

    public Vector3 Seek(Vector3 targetseek)
    {
        Vector3 direction;
       
       direction =  targetseek-transform.position;
        direction.y = 0;

        if (direction.magnitude < 1.0f )
        {
            
            return (Vector3.zero);
        }
        direction.Normalize();
        Vector3 DesiredVelocity = direction * s_MaxSpeed;
        DesiredVelocity = Vector3.ClampMagnitude(DesiredVelocity, s_MaxSpeed);

        return (DesiredVelocity - vc_Velocity);


    }

    //******************************************************************
    public Vector3 Flee(Vector3 targetFlee)
    {
        Vector3 direction;

        direction =  transform.position-targetFlee;
        direction.y = 0;

        if (direction.magnitude>s_panicDist)
        {
           
            return (Vector3.zero);
        }
        direction.Normalize();
        Vector3 DesiredVelocity = direction * s_MaxSpeed;
        DesiredVelocity = Vector3.ClampMagnitude(DesiredVelocity, s_MaxSpeed);

        return (DesiredVelocity - vc_Velocity);


    }

    // Pursuit
    public Vector3 Pursuit(GameObject prey)
    {
        moveVelSimple preyVel = prey.GetComponent<moveVelSimple>();

        float relativeHeading = Vector3.Dot( vc_Heading, preyVel.vc_Heading );
        Vector3 toPrey = prey.transform.position - transform.position;

        float dotPrey = Vector3.Dot( toPrey, vc_Heading );

        // Moving in oposite directions
        if ( dotPrey > 0 && relativeHeading < -0.95f ) {
            return Seek(prey.transform.position);
        } else if ( dotPrey != 1f || dotPrey != -1f) { // Intercept

            float lookAheadTime = (toPrey.magnitude) / (s_MaxSpeed + preyVel.vc_Velocity.magnitude);
            Vector3 futurePos = prey.transform.position + (preyVel.vc_Velocity * lookAheadTime);

            return Seek(futurePos);
        } else {
            return Vector3.zero;
        }
    }

    // Wander
    public Vector3 Wander()
    {
        Vector3 randomVector = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        randomVector.Normalize();
        Vector3 B = randomVector * jitter;
        Vector3 C = targetWander + B;
        targetWander = C;
        C.Normalize();
        C *= wanderRadius;
        Vector3 despCircle = vc_Heading * wanderDistance;//falta multiplicar
        Vector3 direccionMovimiento = despCircle + C;
        return direccionMovimiento;

    }
    // Obstacle avoidance
    public Vector3 ObstacleAvoidance() {
        float distance;
        foreach ( GameObject obstacle in obstacles )
        {
            Vector3 obstaclePos = obstacle.transform.position;
            distance = ( obstaclePos - gameObject.transform.position ).magnitude;
            if ( distance <= avoidanceRadius ) return Flee( obstaclePos );
            return Seek( targetAvoidance.transform.position );
        }
        return Vector3.zero;
    }

    //******************************************************************
    ///  ************** function pursuit*********


    //*************************************************************************
    void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, vc_Heading * 10.0f + transform.position, Color.red);
        Debug.DrawLine(transform.position, transform.forward * 10.0f + transform.position, Color.green);
        

    }

    public void resetBools() {
        OnPursuit = false;
        OnSeek = false;
        OnFlee = false;
        OnWander = false;
        OnPursuit = false;
        OnObstacleAvoidance = false;
    }

    
}
