using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
	public Points pt;
	public Rigidbody rb;

	void OnCollisionEnter(Collision col) {
		if (col.collider.tag == "Target") {
			pt.updatePoints();
			Debug.Log (pt.getPoints ());
		}

        float contact_impulse = 17F;
        float contact_impulse_wall = 7F;

        if (col.collider.tag == "Target" || col.collider.tag == "Wall"){
            ContactPoint contact = col.contacts[0];
            Vector3 contact_point = contact.point;
            Vector3 direction = rb.position - contact_point;
            direction = direction.normalized;
            Vector3 impulse = direction * contact_impulse_wall;
            if(col.collider.tag == "Target") {
                impulse = direction * contact_impulse;
            }
            rb.velocity = impulse;
        }

    }


}
