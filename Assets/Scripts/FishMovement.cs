using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {

    private Transform t;
	// Use this for initialization
	void Start () {
        t = this.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

    void OnTriggerEnter(Collider other)
    {

    }
}
