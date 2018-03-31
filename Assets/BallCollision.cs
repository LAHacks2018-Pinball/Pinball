using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour {

    Rigidbody rb;
    float gravity = -1000.0F;
    float contact_impulse = 20F;
    float startY = 0.2F;
    float startZ = 4.0F;
    float maxX = 3.0F;
    float lengthX = 6.0F;       //The amount X can be below the max X value; (-3, 3) range in this case
    float deadZone = 1;
    float deadZoneNeg;

  

    // Use this for initialization
    void Start () {
        //Physics.gravity = new Vector3(0, gravity, 0);
        deadZoneNeg = deadZone * -1;

        rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(10, 0, 0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //print("Hit");
        //Using only the first contact point for now
        /*
        float contact_impulse = 20F;
        if (collision.collider.gameObject.ToString().Contains("Bumper")){
            ContactPoint contact = collision.contacts[0];
            Vector3 contact_point = contact.point;
            Vector3 direction = rb.position - contact_point;
            direction = direction.normalized;
            Vector3 impulse = direction * contact_impulse;
            rb.velocity = impulse;
        }
        */

        if (collision.collider.gameObject.ToString().Contains("Goal"))
        {
            rb.position = newStart();
            rb.velocity = new Vector3();
        }

    }

    private Vector3 newStart()
    {
        float startX = 0;
        while (startX < deadZone && startX > deadZoneNeg )
        {
            startX = maxX - Random.value * lengthX;
        }
        

        return new Vector3(startX,startY, startZ);
    }
}
