using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    Rigidbody rb;
    float gravity = -1000.0F;

    // Use this for initialization
    void Start () {
        Physics.gravity = new Vector3(0, gravity, 0);
        rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(10, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //print("Hit");
    }
}
