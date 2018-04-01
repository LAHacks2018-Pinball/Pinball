using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerBall : MonoBehaviour
{

    Rigidbody rb;
    Vector3 gravity = new Vector3(0, -9.81F, -13);
    Vector3 neg_gravity = new Vector3(0, -9.81F, 13);
    float contact_impulse = 20F;
	float startX = .25F;
    float startY = -.5F;
    float startZ = 2F;
    float maxX = 1F;
    float lengthX = 6.0F;       //The amount X can be below the max X value; (-3, 3) range in this case
    float deadZone = 1;
    float deadZoneNeg;



    // Use this for initialization
    void Start()
    {
        //Physics.gravity = new Vector3(0, gravity, 0);
        deadZoneNeg = deadZone * -1;

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
		Physics.gravity = gravity;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (rb.position.z <= 0)
        {
            Physics.gravity = gravity;
        }
        else
        {
            //go the opposite way
            Physics.gravity = neg_gravity;
        }
        */
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
            rb.isKinematic = true;
        }

    }

    private Vector3 newStart()
    {
        //float startX = 0;
        //while (startX < deadZone && startX > deadZoneNeg)
        //{
        //    startX = maxX - Random.value * lengthX;
        //}


        return new Vector3(startX, startY, startZ);
    }
}
