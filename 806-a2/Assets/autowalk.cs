using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autowalk : MonoBehaviour {
    public bool moveforward = false;
    public Transform vr_camera;
    public float speed = 2.0f;
    private CharacterController cc;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)){
            change_move_bool();
        }
        if(moveforward){
            Vector3 forward = vr_camera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
		
	}
    void change_move_bool(){
        moveforward = !moveforward;
    }
}
