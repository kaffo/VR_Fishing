using UnityEngine;
using System.Collections;

public class BaitPhysicsController : MonoBehaviour {

    public GameObject fishTemplate;

    private Rigidbody rb;
    private bool hasFish = false;

	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (this.transform.position.y < 0)
        {
            rb.drag = 40;
        }
        else
        {
            rb.drag = 1;
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FishArea") && hasFish == false)
        {
            GameObject fish = Instantiate(fishTemplate);
            fish.transform.SetParent(this.transform);
            fish.transform.localPosition = Vector3.zero;
            fish.transform.localRotation = Quaternion.identity;
            fish.transform.localScale = new Vector3(3, 12, 3);
            hasFish = true;
        }
        if (other.gameObject.CompareTag("Bucket") && hasFish == true)
        {
            if (this.transform.childCount > 0)
            {
                for (var i = 0; i < this.transform.childCount; i++)
                {
                    Destroy(this.transform.GetChild(i).gameObject);
                    hasFish = false;
                }
            }
        }
    }
}
