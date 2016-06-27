using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    public float speedMod = 0.3f;
    public float maxX = 150f;
    public float maxY = 150f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal") * speedMod;
        float moveVertical = Input.GetAxis("Vertical") * speedMod;

        Vector3 boatPos = this.transform.position;
        Vector3 newPos = new Vector3(boatPos.x + moveHorizontal, 0f, boatPos.z + moveVertical);
        if (newPos.x < maxX && newPos.x > -maxX && newPos.z < maxY && newPos.z > -maxY)
        {
            this.transform.position = newPos;
        }
    }
}
