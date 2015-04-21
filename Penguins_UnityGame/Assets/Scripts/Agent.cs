using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour {
    //int BEHAVIOR_STATE; 
    //FiniteStateMachine fsm;
    //public Vector3 velocity;
    Vector3 direction;
    Vector3 acceleration;
    Vector3 targetPosition;

    Agent targetAgent;
    Vector3 target, desired, force;

    public float evadeSensor, pursueSensor;
    public float maxSpeed, maxForce;
    public float mass;

    public UnityEngine.UI.Text label;

    public Vector3 initialVector;
    public enum UseCase { none, randomInitialVelocity, userControlled, wiggle, wander, seek, flee }
    public UseCase useCase;
    public float speed = 10;
    public float timer, angle;
    public List<Sprite> sprites;

    public Agent(Vector3 pos, string name) {
        GetComponent<Rigidbody2D>().position = pos;
        switch (name) {
            case "penguin":
                evadeSensor = 2;
                GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case "seal":
                GetComponent<SpriteRenderer>().sprite = sprites[1];
                evadeSensor = 2;
                pursueSensor = 1;
                break;
            case "orca":
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                pursueSensor = 2;
                break;
        }
    }

    void Start() {
        if (useCase == Agent.UseCase.randomInitialVelocity) { initialVector = Random.insideUnitSphere; }
        initialVector.Normalize();
        GetComponent<Rigidbody2D>().velocity = initialVector * speed;
    }


    void Update() {
        updateMovement();
        updateSteering();
    }

    void updateMovement() {
        switch (useCase) {
            case Agent.UseCase.userControlled:
                float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("vertical");
                GetComponent<Rigidbody2D>().velocity = new Vector3(h, v, 0) * speed;
                break;
            case Agent.UseCase.wiggle:
                initialVector = Random.insideUnitSphere.normalized;
                GetComponent<Rigidbody2D>().velocity = initialVector * speed;
                break;
            case Agent.UseCase.wander:
                if (Time.deltaTime % 15 == 0) {
                    angle = Random.RandomRange(-1.0f, 1.0f) * 360;
                    GetComponent<Rigidbody2D>().angularVelocity = angle;
                }
                GetComponent<Rigidbody2D>().velocity = transform.up * speed;
                break;
            case Agent.UseCase.seek:
                desired = target - targetAgent.transform.position;
                desired.Normalize();
                desired *= targetAgent.maxSpeed;
                force = desired - (Vector3)targetAgent.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = force * (targetAgent.maxForce / targetAgent.maxSpeed);
                break;
            case Agent.UseCase.flee:
                desired = targetAgent.transform.position - target;
                desired *= targetAgent.maxSpeed / desired.magnitude;
                desired.Normalize();
                desired *= targetAgent.maxSpeed;
                force = desired - (Vector3)targetAgent.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = force * (targetAgent.maxForce / targetAgent.maxSpeed);
                break;
        }
    }
    void updateSteering() {

    }

    //void Start() {
        
    //    label.text = "";
    //    label.fontSize = 5;
    //}




    //bool alive;
    //bool showDebugLines;

    ////BoxCollider2D sensorArea;
    ////CircleCollider2D pursueSensor;
    ////Vector3 pursueLocation;
    ////CircleCollider2D evadeSensor;
    ////Vector3 evadeLocation;

    //Vector3 startingPos;

    //void setFSM(FiniteStateMachine a_fsm) {
    //    if (fsm) {
    //        fsm.exit(this);
    //    }
    //    fsm = a_fsm;
    //    if (fsm) {
    //        fsm.enter(this);
    //    }
    //}
    //// Use this for initialization
    //void Start(FiniteStateMachine newFSMBehavior) {
    //    fsm = newFSMBehavior;
    //    mass = GetComponent<Rigidbody2D>().mass;
    //    //pursueSensor = new CircleCollider2D(transform.position, pursueRadius);
    //}
	
    //// Update is called once per frame
    //void Update() {
    //    if (fsm != null) {
    //        fsm.execute(this);
    //    }
    //    updateMovement();
    //}

    //void updateMovement () {
    //    float a_ms = Time.deltaTime;
    //    if (a_ms != 0) {
    //            if(acceleration.magnitude != 0) {
    //                //acceleration. .truncate(maximumForce);
    //                // check the speed, to adjust acceleration so that it doesn't break the speed limit
    //                float currentSpeed = velocity.magnitude;
    //                if (currentSpeed >= maxSpeed) {
    //                    // reduce the acceleration by what it would be contributing to the speed
    //                    Vector3 vDir = velocity / currentSpeed;
    //                    float accelAlignmentWithVelocity = Vector3.Dot(vDir, acceleration);
    //                    if (accelAlignmentWithVelocity > 0) {
    //                        acceleration -= vDir * accelAlignmentWithVelocity;
    //                    }
    //                }
    //            }
    //            velocity += acceleration * (float)a_ms / 1000.0f;
    //            transform.position += velocity * (float)a_ms / 1000.0f;
    //            //sensorArea.set(velocity / 2 + body.center,
    //                //V2f(velocity.magnitude(), body.radius*2), velocity.normal());
    //        }
    //}

}
