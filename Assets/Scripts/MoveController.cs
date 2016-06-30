using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    public GameObject cam;
    public float speedMod = 0.1f;
    public float camSpeedMod = 3f;
    public float maxX = 150f;
    public float maxY = 150f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal") * speedMod;
        float moveVertical = Input.GetAxis("Vertical") * speedMod;
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel") * camSpeedMod;

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            moveBoat(moveHorizontal, moveVertical);
        }
        if (mouseScroll != 0)
        {
            Vector3 camPos = cam.transform.position;
            Vector3 newCamPos = new Vector3(camPos.x, camPos.y - mouseScroll, camPos.z);
            if (newCamPos.y > 2 && newCamPos.y < 50)
            {
                cam.transform.position = newCamPos;
            }
        }
    }

    public void moveBoat(float h, float v)
    {
        Vector3 boatPos = this.transform.position;
        Vector3 newPos = new Vector3(boatPos.x + h, 0f, boatPos.z + v);
        if (newPos.x < maxX && newPos.x > -maxX && newPos.z < maxY && newPos.z > -maxY)
        {
            this.transform.position = newPos;
        }
    }
}
