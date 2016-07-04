using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour {
    private Rigidbody rb;

    public GameObject rod;

    //Variables for fish movement
    [Range(0.0f, 10.0f)]
    public float stamina = 3.0f;
    [Range(0.0f, 1.0f)]
    public float chanceToThrash = 0.5f;
    [Range(0.0f, 1.0f)]
    public float aggressiveness = 0.2f;
    [Range(0.0f, 1.0f)]
    public float likenessY = 0.3f;
    [Range(0.0f, 1.0f)]
    public float likenessAway = 0.6f;
    [Range(0.0f, 1.0f)]
    public float likenessSides = 0.8f;

    private float currentThrashTimer;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        currentThrashTimer = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (currentThrashTimer > 0)
        {
            Vector3 fishForce = Vector3.zero;
            float fishUp = Random.Range(0f, likenessY) * Random.Range(0, aggressiveness);
            float fishAway = Random.Range(0f, likenessAway) * Random.Range(0f, aggressiveness);
            float fishSides = Random.Range(0f, likenessSides) * Random.Range(0f, aggressiveness);

            Vector3 upVector = transform.up * fishUp;

            Vector3 awayFromPlayer = transform.position - rod.transform.position;
            awayFromPlayer.Normalize();
            awayFromPlayer *= fishAway;

            Vector3 sideVector = Vector3.Cross(awayFromPlayer, transform.up);
            sideVector *= fishSides;

            rb.AddForce(upVector + awayFromPlayer + sideVector);

            currentThrashTimer -= Time.deltaTime;
        }
        else
        {
            if (Random.Range(0f, 1f) < chanceToThrash)
            {
                currentThrashTimer = Random.Range(0f, stamina);
            }
        }
	}
}
