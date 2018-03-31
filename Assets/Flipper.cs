using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {

    float spring_force = 10000;
    float spring_damper = 150;
    float rest_position = -32f;
    float pressed_position = 50f;
    bool should_flip = false;
    HingeJoint hinge;
    JointMotor motor;
    JointSpring spring;
    KeyCode keycode;

	// Use this for initialization
	void Start () {


        //Component check so I don't have to make 4 different files controlling the flippers
        string name = ToString();
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
        spring = hinge.spring;
        spring.spring = spring_force;
        spring.damper = spring_damper;
        hinge.spring = spring;
        hinge.useSpring = true;
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

        spring = hinge.spring;
        spring.spring = spring_force;
        spring.damper = spring_damper;
        

        if (should_flip)
        {
            spring.targetPosition = pressed_position;
            //spring.targetPosition = rest_position;
        }
        else
        {
            spring.targetPosition = rest_position;
            //spring.targetPosition = pressed_position;
        }
        hinge.spring = spring;
        
	}

    void flip(bool flip_flag)
    {
        should_flip = flip_flag;
    }
}
