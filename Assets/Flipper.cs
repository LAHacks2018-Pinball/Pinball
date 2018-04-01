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
    bool touch_enabled;
    float touch_x_min;
    float touch_x_max;
    float width;

    public GameObject ball_ref;
    Rigidbody ball_rb; 

	// Use this for initialization
	void Start () {
        print("flip");
		print ("dfsdfdsfs");
        ball_ref = GameObject.Find("Sphere");
        ball_rb = ball_ref.GetComponent<Rigidbody>();

        //Component check so I don't have to make 4 different files controlling the flippers
        string name = ToString();

        width = Screen.width;
        if (name.Contains("P1_Flipper_Left"))
        {
			print ("debug");
			keycode = KeyCode.C;
            touch_enabled = true;
            touch_x_min = 0;
            touch_x_max = width/2;
        }
        if (name.Contains("P1_Flipper_Right"))
        {
			print ("entered in");
            keycode = KeyCode.C;
            touch_enabled = true;
            touch_x_min = width/2;
            touch_x_max = width;
        }
        else if (name.Contains("P2_Flipper_Left"))
        {
            touch_enabled = false;
            keycode = KeyCode.J;
            float temp = rest_position;
            rest_position = pressed_position;
            pressed_position = temp;
        }
        else if (name.Contains("P2_Flipper_Right"))
        {
            touch_enabled = false;
            keycode = KeyCode.L;
            float temp = rest_position;
            rest_position = pressed_position;
            pressed_position = temp;
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
        if(width != Screen.width)
        {
            width = Screen.width;
            string name = ToString();
            if (name.Contains("P1_Flipper_Left"))
            {
                touch_enabled = true;
                touch_x_min = 0;
                touch_x_max = width / 2;
            }
            else if (name.Contains("P1_Flipper_Right"))
            {
                touch_enabled = true;
				touch_x_min = (width / 2) + 1;
                touch_x_max = width;
            }
        }
        
        //For testing on computer
        if (Input.GetKeyDown(keycode))
        {
            
            flip(true);
            ball_rb.isKinematic = false;
        }/*
        if (Input.GetKeyUp(keycode))
        {
            flip(false);
        }
        */
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                float x = touch.position.x;

                if (touch.position.x >= touch_x_min && touch.position.x <= touch_x_max)
                {
                    if(touch.phase == TouchPhase.Began)
                    {
                        flip(true);
                        ball_rb.isKinematic = false;
                    }
                    else if(touch.phase == TouchPhase.Ended)
                    {
                        flip(false);
                    }
                    
                }
            }
            
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
