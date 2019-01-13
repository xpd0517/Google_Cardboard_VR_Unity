using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_walk : MonoBehaviour
{
    public Transform vr_camera;
    public bool moveforward = false;
    public float speed = 2.0f;

    private CharacterController cc;
    public bool magnetDetectionEnabled = true;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        CardboardMagnetSensor.SetEnabled(magnetDetectionEnabled);
        // Disable screen dimming:
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

    }

    // Update is called once per frame
    void Update()
    {
        if (!magnetDetectionEnabled) return;
        if (CardboardMagnetSensor.CheckIfWasClicked())
        {
            change_move_bool();
            // PERFORM ACTION.
            CardboardMagnetSensor.ResetClick();
        }
        if (moveforward)
        {
            Vector3 forward = vr_camera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
    void change_move_bool()
    {
        moveforward = !moveforward;
    }

}
