using UnityEngine;
using System.Collections;

public class RayCastAgent : MonoBehaviour {
    Color originalColor;
    float radius;
    public GameObject lineRenderer; // prefab with line renderer on it w/ 2 points
    public float rayLength = 2;
    public float repelForce = 20;
    public float rayStart = 1.1f;
	// Use this for initialization
	void Start () {
        originalColor = GetComponent<SpriteRenderer>().color;
        radius = GetComponent<CircleCollider2D>().radius;
//        lr = Instantiate(lineRenderer).GetComponent<LineRenderer>();
	}
    GameObject lr;
	// Update is called once per frame
	void Update () {
        Vector2 dir = (Vector2)GetComponent<Rigidbody2D>().velocity;
        dir.Normalize();
        Vector2 start = (Vector2)(transform.position) + dir * radius * rayStart; // 1.1 so it doesn't raycast against itself
        RaycastHit2D hit = Physics2D.Raycast(start, dir, rayLength);
        Lines.Make(ref lr, Color.red, start, start + (dir * rayLength), .1f, 0);
        //lr.SetPosition(0, start);
        //lr.SetPosition(1, start + (dir * rayLength));
        if (hit.collider != null && hit.collider.GetComponent<Agent>() != null) {
            GetComponent<SpriteRenderer>().color = Color.red;
            //dir += hit.normal * repelForce;
            //transform.rotation = Quaternion.LookRotation(dir);
            //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else {
            GetComponent<SpriteRenderer>().color = originalColor;
        }
	}
}
