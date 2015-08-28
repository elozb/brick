using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshGen : MonoBehaviour {
	
	//버텍스의 위치..
	public List<Vector3> listVertex = new List<Vector3>();
	//버텍스의 인덱스..
	public List<int> listTri = new List<int>();
	public List<Vector2> listUV = new List<Vector2> ();
	
	protected Mesh mesh;
	
	// Use this for initialization
	void Start () {
		/*
		mesh = GetComponent<MeshFilter> ().mesh;
		
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;
		
		listVertex.Add(new Vector3(x-10, y+5,z));
		listVertex.Add(new Vector3(x+10, y+5,z));
		listVertex.Add(new Vector3(x-10, y-5,z));
		listVertex.Add(new Vector3(x+10, y-5,z));
		*/

		
		
		
		
	}
	protected void GenMesh()
	{
		if (mesh == null) {
			return;
		}
			
		//1번 폴리곤..
		listTri.Add (0);
		listTri.Add (1);
		listTri.Add (2);
		//2번 폴리곤..
		listTri.Add (1);
		listTri.Add (3);
		listTri.Add (2);
		
		
		//텍스쳐의 좌표를 UV에 넣습니다.
		listUV.Add (new Vector2 (0, 0));
		listUV.Add (new Vector2 (1, 0));
		listUV.Add (new Vector2 (0, 1));
		listUV.Add (new Vector2 (1, 1));
		
		
		//메쉬 클리어..
		mesh.Clear ();
		//버텍스 데이터..
		mesh.vertices = listVertex.ToArray ();
		//UV데이터
		mesh.uv = listUV.ToArray ();
		
		// 폴리곤 인덱스배열..
		mesh.triangles = listTri.ToArray ();
		//메쉬 생성..
		mesh.Optimize ();
		mesh.RecalculateNormals ();
	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
}
