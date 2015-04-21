using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class setVelocity : MonoBehaviour {
    Agent targetAgent;
    Vector3 target, desired, force;

    public Vector3 initialVector;
    public enum UseCase { none, randomInitialVelocity, userControlled, wiggle, wander, seek, flee }
    public UseCase useCase;
    public float speed = 10;
    public float timer, angle;

    void Start() {
        if (useCase == UseCase.randomInitialVelocity) { initialVector = Random.insideUnitSphere; }
        GetComponent<Rigidbody2D>().velocity = initialVector * speed;
    }


    void Update() {
        switch (useCase) {
            case UseCase.userControlled:
                float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("vertical");
                GetComponent<Rigidbody2D>().velocity = new Vector3(h, v, 0) * speed;
                break;
            case UseCase.wiggle:
                initialVector = Random.insideUnitSphere.normalized;
                GetComponent<Rigidbody2D>().velocity = initialVector * speed;
                break;
            case UseCase.wander:
                if((timer -= Time.deltaTime) <= 0) {
				    angle = Random.RandomRange(-1.0f, 1.0f) * 720;
				    timer = Random.RandomRange(0.0f, 1.0f);
				    GetComponent<Rigidbody2D>().angularVelocity = angle;
			    }
			    GetComponent<Rigidbody2D>().velocity = transform.up * speed;
			    break;
            case UseCase.seek:
                desired = target - targetAgent.transform.position;
                desired.Normalize();
                desired *= targetAgent.maxSpeed;
                force = desired - (Vector3)targetAgent.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = force * (targetAgent.maxForce / targetAgent.maxSpeed);
                break;
            case UseCase.flee:
                desired = targetAgent.transform.position - target;
                desired *= targetAgent.maxSpeed / desired.magnitude;
                desired.Normalize();
                desired *= targetAgent.maxSpeed;
                force = desired - (Vector3)targetAgent.GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = force * (targetAgent.maxForce / targetAgent.maxSpeed);
                break;
        }
    }

    void seek(Vector3 target, Agent agent) {
        targetAgent = agent;
        this.target = target;
        useCase = UseCase.seek;
    }

    void flee(Vector3 target, Agent agent) {
        targetAgent = agent;
        this.target = target;
        useCase = UseCase.flee;
    }
}
