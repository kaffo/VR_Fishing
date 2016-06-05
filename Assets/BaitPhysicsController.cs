using UnityEngine;
using System.Collections;

public class BaitPhysicsController : MonoBehaviour {

    public GameObject rod;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log(rb.velocity);
        Debug.Log(transform.localPosition);
        if (this.transform.localPosition.magnitude > 75)
        {
            rb.velocity.Scale(new Vector3(-1.0f, -1.0f, -1.0f));
        }
	}
}
