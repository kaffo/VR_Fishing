using UnityEngine;
using System.Collections;

public class ReelController : MonoBehaviour {
    public GameObject rod;
    public GameObject reelHandle;

    private Transform reelHandleTransform;

	// Use this for initialization
	void Start () {
        reelHandleTransform = reelHandle.GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.position = rod.transform.position + new Vector3(-0.02f, -0.5f, 0f);
    }

    void FixedUpdate ()
    {
        reelHandleTransform.localEulerAngles = new Vector3 (0f, 0f, 0f);
    }
}
