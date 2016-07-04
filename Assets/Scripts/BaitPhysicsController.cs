using UnityEngine;
using System.Collections;

public class BaitPhysicsController : MonoBehaviour {

    public GameObject fishTemplate;
    public GameObject controllerManager;
    public GameObject rod;

    private Rigidbody rb;
    private SteamVR_ControllerManager conManScript;
    private GameObject fish;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        conManScript = controllerManager.GetComponent<SteamVR_ControllerManager>();
        fish = null;
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
        if (other.gameObject.CompareTag("FishArea") && fish == null)
        {
            fish = Instantiate(fishTemplate);
            fish.transform.eulerAngles = new Vector3(90, 0, 0);
            fish.transform.position = transform.position - new Vector3(0, 0, -0.2f);
            fish.GetComponent<FixedJoint>().connectedBody = rb;
            fish.GetComponent<FishMovement>().rod = rod;       
            conManScript.Rumble(1, 500);
        }
        if (other.gameObject.CompareTag("Bucket") && fish != null)
        {
            Destroy(fish);
            fish = null;
        }
    }
}
