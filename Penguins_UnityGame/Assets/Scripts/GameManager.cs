using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    [System.Serializable]
    public struct JustGameThings {
        public string name;
        public int count;
        public Agent prefab;
        public List<Agent> list;
        

        public void Start(BoxCollider box) {            
            list = new List<Agent>();
            for (int i = 0; i < count; ++i) {
                GameObject go = Instantiate(prefab.gameObject);
                list.Add(go.GetComponent<Agent>());
                //float s = Camera.main.orthographicSize;
                //float a = Camera.main.aspect;
                //float w = s * a * 2, h = s / a * 2;
                //Vector3 randomPos = new Vector3(Random.Range(0f, w)-w/2, Random.Range(0, h)-h/2, 0);

                Vector3 randomPos = box.size;
                randomPos.x *= Random.Range(0.0f, 1.0f);
                randomPos.y *= Random.Range(0.0f, 1.0f);
                randomPos -= new Vector3(box.size.x/2, box.size.y/2, 0);
                go.transform.position = randomPos;
            }
        }
    }

    public List<JustGameThings> gameThings = new List<JustGameThings>();

    public Transform wallParent;

    public JustGameThings penguins {
        get { return gameThings[0]; }
    }
    public JustGameThings seals {
        get { return gameThings[1]; }
    }
    public JustGameThings orcas {
        get { return gameThings[2]; }
    }
	
    // Use this for initialization
	void Start () {
        for(int i = 0; i < gameThings.Count; ++i) {
            gameThings[i].Start(GetComponent<BoxCollider>());
        }
	}

    // Update is called once per frame
    void Update() {
        
	}
}