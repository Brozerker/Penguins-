using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    [System.Serializable]
    public class SpawnDetails {
        public string name;
        public GameObject thingToSpawn;
        public float weight = 1;
    }
    public SpawnDetails[] thingsToSpawn;
    [Tooltip("how many seconds to wait between spawns")]
    public float spawnRate = 1;
    float cooldownTimer;
    BoxCollider area;
    public List<GameObject> population;
    public float spawnMax = 100;

    public SpawnDetails PickRandomSpawn() {
        float allWeights = 0;
        for (int i = 0; i < thingsToSpawn.Length; ++i) {
            allWeights += thingsToSpawn[i].weight;
        }
        float random = Random.Range(0.0f, 1.0f) * allWeights;
        for (int i = 0; i < thingsToSpawn.Length; ++i) {
            random -= thingsToSpawn[i].weight;
            if (random <= 0) {
                return thingsToSpawn[i];
            }
        }
        return thingsToSpawn[0];
    }

    void Start() {
        area = GetComponent<BoxCollider>();

    }

    void Update() {
        if (cooldownTimer <= 0) {
            Vector3 whereToPut = transform.position;
            if (area != null) {
                whereToPut = area.size;
                whereToPut.x *= Random.Range(0.0f, 1.0f);
                whereToPut.y *= Random.Range(0.0f, 1.0f);
                whereToPut.z *= Random.Range(0.0f, 1.0f);
                whereToPut += area.center - area.size / 2 + transform.position;
            }
            if (population.Count < spawnMax) {
                GameObject go = (GameObject)Instantiate(
                    PickRandomSpawn().thingToSpawn, whereToPut, Quaternion.identity);
                population.Add(go);
                cooldownTimer = spawnRate;
            }
            else {
                cooldownTimer = 0;
            }
        }
        cooldownTimer -= Time.deltaTime;
    }
}
