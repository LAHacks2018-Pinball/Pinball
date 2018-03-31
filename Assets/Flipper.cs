using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    float motor_force = 1000;
    float target_velocity = 1000;
    bool should_flip = false;
    HingeJoint hinge;
    KeyCode keycode;

	// Use this for initialization
	void Start () {
        //Component check so I don't have to make 4 different files controlling the flippers
        string name = ToString();
        print(name);
        if (name == "P1_Flipper_Left (Flipper)")
        {
            keycode = KeyCode.Z;
        }
        else if (name == "P1_Flipper_Right (Flipper)")
        {
            keycode = KeyCode.C;
        }
        else if (name == "P2_Flipper_Left (Flipper)")
        {
            keycode = KeyCode.J;
        }
        else if (name == "P2_Flipper_Right (Flipper)")
        {
            keycode = KeyCode.L;
        }
        else
        {
            //Error
            print("Flipper ID Error");
        }


        hinge = GetComponent<HingeJoint>();
        JointMotor motor = hinge.motor;
        motor.force = motor_force;
        motor.targetVelocity = target_velocity;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = false;
    }
	
	// Update is called once per frame
	void Update () {
        //For testing on computer
        if (Input.GetKeyDown(keycode))
        {
            flip(true);
        }
        if (Input.GetKeyUp(keycode))
        {
            flip(false);
        }

        hinge.useMotor = should_flip;
	}

    void flip(bool flip_flag)
    {
        should_flip = flip_flag;
    }
}
