using UnityEngine;
using System.Collections;

public class FishAreaMoveController : MonoBehaviour {

    public Vector3 destination;
    public float speed = 0.01f;

	// Use this for initialization
	void Start () {
        //destination = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        if (transform.position == destination)
        {
            transform.parent.GetComponent<FishController>().newFishArea();
            Destroy(gameObject);
        }
    }
}