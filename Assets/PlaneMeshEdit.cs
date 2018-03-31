using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMeshEdit : MonoBehaviour {

    MeshFilter mf;
    Mesh mesh;

	// Use this for initialization
	void Start () {
        mf = GetComponent<MeshFilter>();
        mesh = mf.mesh;
        Vector3[] vertices = mesh.vertices;


        //change the plane to be higher in the center to allow pinballs to roll to either side
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
