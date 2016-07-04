using UnityEngine;
using System.Collections;

public class BaitPhysicsController : MonoBehaviour {

    public GameObject fishTemplate;
    public GameObject controllerManager;

    private Rigidbody rb;
    private SteamVR_ControllerManager conManScript;
    private bool hasFish = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        conManScript = controllerManager.GetComponent<SteamVR_ControllerManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.position.y < 0)
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
            //TODO Refactor all this
            GameObject fish = Instantiate(fishTemplate);
            fish.transform.eulerAngles = new Vector3(90, 0, 0);
            fish.transform.position = transform.position - new Vector3(0, 0, -0.3f);
            fish.GetComponent<FixedJoint>().connectedBody = rb;
            conManScript.Rumble(1, 2000);
            hasFish = true;
        }
        if (other.gameObject.CompareTag("Bucket") && hasFish == true)
        {
            if (transform.childCount > 0)
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                    hasFish = false;
                }
            }
        }
    }
}
