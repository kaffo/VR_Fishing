using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {
    public GameObject rod;
    public GameObject hook;

    //Variables for fish movement
    [Range(0.0f, 10.0f)]
    public float stamina = 8.0f;
    [Range(0.0f, 10.0f)]
    public float staminaMin = 2.0f;
    [Range(0.0f, 1.0f)]
    public float chanceToThrash = 0.5f;
    [Range(0.0f, 10.0f)]
    public float aggressiveness = 3f;
    [Range(0.0f, 1.0f)]
    public float likenessY = 0.3f;
    [Range(0.0f, 1.0f)]
    public float likenessAway = 0.6f;
    [Range(0.0f, 1.0f)]
    public float likenessSides = 0.8f;

    private float currentThrashTimer;
    private Rigidbody rb;
    private Rigidbody hookrb;
    private Vector3 fishForce;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        hookrb = hook.GetComponent<Rigidbody>();
        currentThrashTimer = 0;
        fishForce = Vector3.zero;

        //GetComponent<FixedJoint>().breakForce = 100f;
	}

	// Update is called once per frame
	void Update () {
        if (currentThrashTimer > 0)
        {
            currentThrashTimer -= Time.deltaTime;
        }
        else
        {
            if (Random.Range(0f, 1f) < chanceToThrash)
            {
                currentThrashTimer = Random.Range(staminaMin, stamina);

                float fishUp = Random.Range(-likenessY, likenessY) * Random.Range(0, aggressiveness);
                float fishAway = Random.Range(0f, likenessAway) * Random.Range(0f, aggressiveness);
                float fishSides = Random.Range(-likenessSides, likenessSides) * Random.Range(0f, aggressiveness);

                Vector3 upVector = transform.up * fishUp;

                Vector3 awayFromPlayer = transform.position - rod.transform.position;
                awayFromPlayer.Normalize();
                awayFromPlayer *= fishAway;

                Vector3 sideVector = Vector3.Cross(awayFromPlayer, transform.up);
                sideVector *= fishSides;

                fishForce = upVector + awayFromPlayer + sideVector;
                //Debug.Log("Time: " + currentThrashTimer);
                //Debug.Log("Up: " + upVector + " Away: " + awayFromPlayer + " Sides: " + sideVector + " Final: " + fishForce);
                Debug.DrawLine(transform.position, transform.position + fishForce, Color.yellow, currentThrashTimer);
            }
        }
	}

    void FixedUpdate()
    {
        if (currentThrashTimer > 0)
        {
            if (transform.position.y > 0)
            {
                rb.AddForce(fishForce * 0.1f, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(fishForce, ForceMode.Impulse);
            }
        }
    }
}
