using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private static GameManager _instance;  
	public static GameManager Instance  
	{  
		get  
		{  
			if (!_instance)  
			{  
				_instance = GameObject.FindObjectOfType(typeof(GameManager))  as GameManager;  
				if (!_instance)  
				{  
					GameObject container = new GameObject();  
					container.name = "DataManagerContainer";  
					_instance = container.AddComponent(typeof(GameManager)) as GameManager;  
				}  
			}  
			
			return _instance;  
		}  
	} 

	ArrayList listBall;

	GameObject userControllUnit;

//	// Use this for initialization
//	void Start () {
//	
//	}
//
	void Awake(){

		GameObject ball = Resources.Load ("Prefabs/ball") as GameObject;
		if (ball == null) {
			Debug.LogError("ball 프리펩을 가져올수 없음");
		}

		userControllUnit = Resources.Load ("Prefabs/ControllUnit") as GameObject;
		if (userControllUnit == null) {
			Debug.LogError("userControllUnit 프리펩을 가져올수 없음");
		}

		DataManager.Instance.Init ();


	}

	// Update is called once per frame
	void Update () {
		
	}
}
