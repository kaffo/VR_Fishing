using UnityEngine;
using System.Collections.Generic;
using Valve.VR;

public class InputManager : MonoBehaviour
{
    public GameObject boat;
    public GameObject rod;
    public GameObject hook;
    public GameObject rodTrigger;
    public float reelSpeed = 0.04f;
    public float minReelLength = 0.7f;

    private SpringJoint rodJoint;
    private bool lineFree = false;
    private bool lineSlack = true;

    private Transform rodTransform;
    private Transform hookTransform;
    private MoveController boatMoveController;

    private SteamVR_Action_Vibration hapticAction = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");

    void Start()
    {
        rodJoint = rod.GetComponent<SpringJoint>();
        rodTransform = rod.GetComponent<Transform>();
        hookTransform = hook.GetComponent<Transform>();
        boatMoveController = boat.GetComponent<MoveController>();
    }

    void Update()
    {
        if (SteamVR_Actions._default.GrabGrip[SteamVR_Input_Sources.RightHand].state)
        {
            rodTrigger.SetActive(true);
            lineFree = true;
            rodJoint.maxDistance = 300f;
            Debug.Log("Holding...");
        }
        else if (lineFree == true)
        {
            rodTrigger.SetActive(false);
            lineFree = false;
            rodJoint.maxDistance = Vector3.Distance(rodTransform.position, hookTransform.position);
            Debug.Log("Line Locked at: " + rodJoint.maxDistance);
        }

        if (SteamVR_Actions._default.ReleaseReel[SteamVR_Input_Sources.LeftHand].state)
        {
            if (rodJoint.maxDistance > minReelLength && lineFree == false && lineSlack == true)
            {
                rodJoint.maxDistance -= reelSpeed;
                Rumble(SteamVR_Input_Sources.LeftHand ,1000);
                Rumble(SteamVR_Input_Sources.RightHand, 1000);
            }
        }

        if (SteamVR_Actions._default.ReleaseReel[SteamVR_Input_Sources.RightHand].state)
        {
            Vector2 axis = new Vector2 (0, 0); //SteamVR_Controller.Input(index).GetAxis(axisIds[0]); TODO FIX ME
            float boatSpeed = boatMoveController.speedMod;
            boatMoveController.moveBoat(axis.x * boatSpeed, axis.y * boatSpeed);
        }
    }
    public void Rumble(SteamVR_Input_Sources leftOrRight, ushort duration)
    {
        float seconds = (float)duration / 1000000f;
        hapticAction.Execute(0, seconds, 1f / seconds, 1, leftOrRight);
    }
    public void SetLineSlack(bool _lineSlack)
    {
        lineSlack = _lineSlack;
    }
}