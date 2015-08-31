using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	//공의 진행방향..
	Vector3 direction;

	//공의 스피드..
	float speed;

	public void Init()
	{
//		direction = new Vector3 (0.1f, 1f, 0f);
//		speed = 1;
//
		Init (new Vector3 (0.1f, 1f, 0f), 1);
	}


	public void Init (Vector3 dir, float spd)
	{
		direction = dir;
		speed = spd;
	}

	public void SetDirection(Vector3 dir)
	{
		direction = dir;
	}


	void Update () {

	}
}
