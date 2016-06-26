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
            
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
        {
            other.gameObject.transform.SetParent(this.transform);
            other.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            other.gameObject.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        if (other.gameObject.CompareTag("Bucket"))
        {
            if (this.transform.childCount > 0)
            {
                for (var i = 0; i < this.transform.childCount; i++)
                {
                    this.transform.GetChild(i).transform.SetParent(other.transform);
                }
            }
        }
    }
}
