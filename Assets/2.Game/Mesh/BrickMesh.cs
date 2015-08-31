using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BrickMesh : MeshGen {
	
	// Use this for initialization
	void Start () {

		mesh = GetComponent<MeshFilter> ().mesh;
		

		listVertex.Add(new Vector3(-10, 5,0));
		listVertex.Add(new Vector3(10, 5,0));
		listVertex.Add(new Vector3(-10, -5,0));
		listVertex.Add(new Vector3(10, -5,0));

		GenMesh ();

	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
}
