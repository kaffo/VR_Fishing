using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour {
    public GameObject rod;
    public GameObject hook;

    private LineRenderer lr;
    private Vector3 rodPos;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        rodPos = rod.transform.TransformPoint(new Vector3(0, 1, 0));
        lr.SetPosition(0, rodPos);
        lr.SetPosition(1, hook.transform.position);
	}
}
