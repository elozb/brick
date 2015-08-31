using UnityEngine;
using System.Collections;

public class DataManager : MonoBehaviour {

	private static DataManager _instance;  
	public static DataManager Instance  
	{  
		get  
		{  
			if (!_instance)  
			{  
				_instance = GameObject.FindObjectOfType(typeof(DataManager))  as DataManager;  
				if (!_instance)  
				{  
					GameObject container = new GameObject();  
					container.name = "DataManagerContainer";  
					_instance = container.AddComponent(typeof(DataManager)) as DataManager;  
				}  
			}  
			
			return _instance;  
		}  
	} 

	//블록 가로 세로 행과 열
	const int BLOCK_ROW = 13;
	const int BLOCK_COLUMN = 20;

	//블록개체의 가로세로 사이즈
	const float BLOCK_WIDTH = 20.0f;
	const float BLOCK_HEIGHT = 15.0f;

	//게임판의 전체 사이즈
	const float GAMEPANEL_WIDTH = BLOCK_WIDTH * BLOCK_ROW;
	const float GAMEPANEL_HEIGHT = BLOCK_HEIGHT * (BLOCK_COLUMN + 10);	//하단의 플레이어 유닛부터 블록이 놓일 부분까지 약 10칸..

	int[,] brickData;

	GameObject brick;
	// Use this for initialization
	void Awake()
	{
		brick = Resources.Load ("Prefabs/brick") as GameObject;
		initBlock ();
		ArrangeBlock ();
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void initBlock()
	{
		//차후에 외부 에서 불러오는 형식으로..

		brickData = new int[BLOCK_COLUMN,BLOCK_ROW]{
					{0,0,0,0,0,0,0,0,0,0,0,0,0},
					{0,0,0,0,0,0,0,0,0,0,0,0,0},
					{0,0,0,0,0,0,0,0,0,0,0,0,0},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{1,1,1,1,1,1,1,1,1,1,1,1,1},
					{0,0,0,0,0,0,0,0,0,0,0,0,0}
		};
	}

	void ArrangeBlock()
	{
		//벽돌 배치..
		for (int i = 0; i<BLOCK_COLUMN; i++) {
			for (int j = 0; j<BLOCK_ROW; j++) {
				if(blocks[i,j] == 0)
				{
					continue;
				}
				//0이아닌경우 블록 배치..

				// 실제 인스턴스 생성

				GameObject cloneBrick = MonoBehaviour.Instantiate (brick) as GameObject;

				cloneBrick.name = "brick_"+i.ToString()+"_"+j.ToString; // name을 변경
				cloneBrick.transform.parent = player.transform;
				// bullet을 player에 입양하는등 초기화작업 수행
			}
		}
	}
}
