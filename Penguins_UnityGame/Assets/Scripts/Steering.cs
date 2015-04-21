//using UnityEngine;
//using System.Collections;


//public class Steering : MonoBehaviour {
//    float a_ms = Time.deltaTime;
//    //TemplateVector<Obstacle*> actualHits;
//    //TemplateVector<V2f> hitLocations;
//    //TemplateVector<V2f> hitNormals;
//    //TemplateVector<float> hitForce;
//    //void clear() {
//    //    actualHits.clear();
//    //    hitLocations.clear();
//    //    hitNormals.clear();
//    //    hitForce.clear();
//    //}

//    Vector3 seek(Vector3 target, Agent agent) {
//        Vector3 desired = target - agent.transform.position;
//        desired.Normalize();
//        desired *= agent.maxSpeed;
//        Vector3 force = desired - agent.velocity;
//        return force * (agent.maxForce / agent.maxSpeed);
//    }

//    Vector3 stop(Agent agent) {
//        if(!(agent.velocity.magnitude == 0)) {
//            Vector3 v = agent.velocity;
//            if (a_ms != 0) {
//                Vector3 perfectAccelToStop = -v * 1000.0f / (float)a_ms;
//                float mag = perfectAccelToStop.magnitude;
//                if(mag <= agent.maxForce)
//                    return perfectAccelToStop;
//            }
//            if(v.magnitude > 0)
//                return -v * (agent.maxForce / v.magnitude);
//        }
//        return new Vector3(0,0,0);
//    }

//    Vector3 flee(Vector3 target, Agent agent) {
//        //	vec2 desired = target - agent.position;
//        Vector3 desired = agent.transform.position - target;
//        //	desired *= agent.maxSpeed / desired.mag();
//        //desired *= agent->maximumSpeed / desired.magnitude();
//        desired.Normalize();
//        desired *= agent.maxSpeed;
//        //	vec2 force = desired - agent.velocity;
//        Vector3 force = desired - agent.velocity;
//        //	return force * (agent.maxForce / agent.maxSpeed);
//        return force * (agent.maxForce / agent.maxSpeed);
//        //}
//    }

//    //Vector3 obstacleAvoidance(TemplateVector<Obstacle*> * obstacles,
//    //    Obstacle * sensorArea, Agent * agent,
//    //    CalculationsFor_ObstacleAvoidance * calc);

//    //Vector3 alignment(Agent * agent, TemplateVector<Agent*> & neighbors);

//    //Vector3 cohesion(Agent * agent, TemplateVector<Agent*> & neighbors);

//    //Vector3 separation(Agent * agent, float neighborRadius, TemplateVector<Agent*> & neighbors);

//    //Vector3 flock(Agent * agent, TemplateVector<Agent*>& neighbors, float neighborRadius);

//    //Vector3 pursue(Agent * agent, Agent * target);

//    //Vector3 evade(Agent * agent, Agent * toEvade);

//    //Vector3 arrive(Agent * agent, Vector3 target, int a_ms);

//    public Vector3 wander(Agent agent) {
//    //create structure for steering vector
//        Vector3 newDirection;
//        //get velocity from vector form of orientation
//        newDirection = agent.velocity;
//        //change orientation randomly betwee 0 - PI
//        float randomRotation = Random.RandomRange(-90f, 90f);
//        newDirection *= randomRotation/180;
//        //output steering
//        return newDirection;
//    }

//    //Vector2 followPath(Agent * agent);

//    //V2f path_follow(Agent * agent);
//};
