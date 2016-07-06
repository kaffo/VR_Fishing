using UnityEngine;
using System.Collections;

public class BaitPhysicsController : MonoBehaviour {

    public GameObject fishTemplate;
    public GameObject controllerManager;
    public GameObject rod;

    private Rigidbody rb;
    private SpringJoint rodJoint;
    private SteamVR_ControllerManager conManScript;
    private GameObject fish;

    private float rodToHook;
    private float streach;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rodJoint = rod.GetComponent<SpringJoint>();
        conManScript = controllerManager.GetComponent<SteamVR_ControllerManager>();
        fish = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < 0)
        {
            rb.drag = 40;
            rodToHook = Vector3.Distance(rod.transform.position, transform.position);
            streach = rodToHook - (rodJoint.maxDistance + 1.0f);
            if (fish != null && streach > 0)
            {
                //Debug.Log("Mag: " + Vector3.Distance(rod.transform.position, transform.position) + " Dist: " + rodJoint.maxDistance);
                conManScript.Rumble(1, (ushort)(500 * streach));
            }
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
            fish.GetComponent<FishMovement>().hook = gameObject;
            conManScript.Rumble(1, 2000);
        }
        if (other.gameObject.CompareTag("Bucket") && fish != null)
        {
            Destroy(fish);
            fish = null;
        }
    }
}
