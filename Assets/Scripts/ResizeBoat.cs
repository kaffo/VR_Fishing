using UnityEngine;
using System.Collections;
using Valve.VR;

public class ResizeBoat : MonoBehaviour {
    public GameObject boatBottom;
    public GameObject playArea;
    public GameObject bucket;
    public float boatX = 0.8f;
    public float boatZ = 0.8f;

    // Use this for initialization
    void Start() {
        if (playArea.activeSelf == true)
        {
            var boatTransform = boatBottom.GetComponent<Transform>();
            var bucketTransform = bucket.GetComponent<Transform>();

            var chaperone = OpenVR.Chaperone;
            float playAreaX = 2.0f;
            float playAreaY = 2.0f;
            bool success = (chaperone != null);
            if (success)
                chaperone.GetPlayAreaSize(ref playAreaX, ref playAreaY);
            else
                Debug.Log("Error loading Chaperone");
            Debug.Log("X:" + playAreaX.ToString() + " Y:" + playAreaY.ToString());
            boatTransform.localScale = new Vector3(playAreaX * boatX, 0.1f, playAreaY * boatZ);
            bucketTransform.localPosition = new Vector3(0.4f, 2f, 0.4f);
        }
        else Debug.Log("Play Area not active");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
