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

    private float fishAreaX;
    private float fishAreaY;
    private float fishAreaZ;

    private float fishAreaSizeX;
    private float fishAreaSizeY;
    private float fishAreaSizeZ;

    private Vector3 fishAreaPos;
    private Vector3 fishAreaScale;

    // Use this for initialization
    void Start () {
        for (var i = 0; i < maxFishAreas; i++)
        {
            newFishArea();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void newFishArea()
    {
        fishAreaX = Random.Range(-maxFishAreaX, maxFishAreaX);
        fishAreaY = Random.Range(-maxFishAreaY, 0);
        fishAreaZ = Random.Range(-maxFishAreaZ, maxFishAreaZ);

        fishAreaPos = new Vector3(fishAreaX, fishAreaY, fishAreaZ);

        GameObject fishArea = (GameObject)Instantiate(templateFishArea, fishAreaPos, Quaternion.identity);

        fishArea.transform.SetParent(transform);

        fishAreaSizeX = Random.Range(1, maxFishAreaSizeX);
        fishAreaSizeY = Random.Range(1, maxFishAreaSizeY);
        fishAreaSizeZ = Random.Range(1, maxFishAreaSizeZ);

        fishAreaScale = new Vector3(fishAreaSizeX, fishAreaSizeY, fishAreaSizeZ);

        fishArea.transform.localScale = fishAreaScale;

        Vector3 fishAreaDest = new Vector3(Random.Range(-maxFishAreaX, maxFishAreaX), Random.Range(-maxFishAreaY, 0), Random.Range(-maxFishAreaZ, maxFishAreaZ));

        FishAreaMoveController fishAreaScript = fishArea.GetComponent<FishAreaMoveController>();
        fishAreaScript.destination = fishAreaDest;
    }
}
