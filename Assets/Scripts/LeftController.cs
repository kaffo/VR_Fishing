using UnityEngine;
using System.Collections;

public class LeftController : MonoBehaviour {
    public GameObject controllerManager;

	// Use this for initialization
	void Start () {
	    
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reel"))
        {
            controllerManager.GetComponent<SteamVR_ControllerManager>().setReelTouching(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reel"))
        {
            controllerManager.GetComponent<SteamVR_ControllerManager>().setReelTouching(false);
        }
    }
}