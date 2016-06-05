using UnityEngine;
using System.Collections;
using Valve.VR;

public class ResizeBoat : MonoBehaviour {
    public GameObject boatBottom;
    public GameObject playArea;

    // Use this for initialization
    void Start() {
        if (playArea.activeSelf == true)
        {
            var boatTransform = boatBottom.GetComponent<Transform>();

            var chaperone = OpenVR.Chaperone;
            float playAreaX = 2.0f;
            float playAreaY = 2.0f;
            bool success = (chaperone != null);
            if (success)
                chaperone.GetPlayAreaSize(ref playAreaX, ref playAreaY);
            else
                Debug.Log("Error loading Chaperone");
            Debug.Log("X:" + playAreaX.ToString() + " Y:" + playAreaY.ToString());
            boatTransform.localScale = new Vector3(playAreaX * 0.8f, 0.1f, playAreaY * 0.6f);
        }
        else Debug.Log("Play Area not active");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
