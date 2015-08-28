using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickMesh : MeshGen {
	
	// Use this for initialization
	void Start () {

		mesh = GetComponent<MeshFilter> ().mesh;
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		
		listVertex.Add(new Vector3(x-10, y+5,z));
		listVertex.Add(new Vector3(x+10, y+5,z));
		listVertex.Add(new Vector3(x-10, y-5,z));
		listVertex.Add(new Vector3(x+10, y-5,z));

		GenMesh ();

	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
}
