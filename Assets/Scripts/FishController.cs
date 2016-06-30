using UnityEngine;
using System.Collections;

public class FishController : MonoBehaviour {
    public GameObject templateFishArea;
    public float maxFishAreaX = 150f;
    public float maxFishAreaY = 25f;
    public float maxFishAreaZ = 150f;

    public float maxFishAreaSizeX = 10f;
    public float maxFishAreaSizeY = 10f;
    public float maxFishAreaSizeZ = 10f;

    public int maxFishAreas = 5;

    // Use this for initialization
    void Start () {
        float fishAreaX;
        float fishAreaY;
        float fishAreaZ;

        float fishAreaSizeX;
        float fishAreaSizeY;
        float fishAreaSizeZ;

        Vector3 fishAreaPos;
        Vector3 fishAreaScale;

        for (var i = 0; i < maxFishAreas; i++)
        {

            fishAreaX = Random.Range(-maxFishAreaX, maxFishAreaX);
            fishAreaY = Random.Range(-maxFishAreaY, 0);
            fishAreaZ = Random.Range(-maxFishAreaZ, maxFishAreaZ);

            fishAreaPos = new Vector3(fishAreaX, fishAreaY, fishAreaZ);

            GameObject fishArea = (GameObject) Instantiate(templateFishArea, fishAreaPos, Quaternion.identity);

            fishArea.transform.SetParent(this.transform);

            fishAreaSizeX = Random.Range(1, maxFishAreaSizeX);
            fishAreaSizeY = Random.Range(1, maxFishAreaSizeY);
            fishAreaSizeZ = Random.Range(1, maxFishAreaSizeZ);

            fishAreaScale = new Vector3(fishAreaSizeX, fishAreaSizeY, fishAreaSizeZ);

            fishArea.transform.localScale = fishAreaScale;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
