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
					container.name = "DataManager";  
					_instance = container.AddComponent(typeof(DataManager)) as DataManager;  
				}  
			}  
			
			return _instance;  
		}  
	} 

	//블록 가로 세로 행과 열..
	const int BRICK_ROW = 13;
	const int BRICK_COLUMN = 20;

	//블록개체의 가로세로 사이즈..
	const float BRICK_WIDTH = 20.0f;
	const float BRICK_HEIGHT = 10.0f;

	//게임판의 전체 사이즈..
	const float GAMEPANEL_WIDTH = BRICK_WIDTH * BRICK_ROW;
	const float GAMEPANEL_HEIGHT = BRICK_HEIGHT * (BRICK_COLUMN + 10);	//하단의 플레이어 유닛부터 블록이 놓일 부분까지 약 10칸..

	int[,] brickData;

	GameObject brick;		//브릭 오브젝트..

	public GameObject brickPanel;	//브릭의 부모 객체..


	public void Init (){
		brick = Resources.Load ("Prefabs/brick") as GameObject;
		if (brick == null) {
			Debug.LogError("brick 프리펩을 찾을수없습니다.");
		}
		brickPanel = GameObject.Find ("brickPanel");
		if (brickPanel == null) {
			Debug.LogError("brickPanel 오브젝트가 하이라키에 없습니다.");
		}

		InitBrick ();		//데이터 초기화..
		ArrangeBrick ();	//brick 배치..
	}


	void InitBrick()
	{
		//차후에 외부 에서 불러오는 형식으로..

		brickData = new int[BRICK_COLUMN,BRICK_ROW]{
					{0,0,0,0,0,0,0,0,0,0,0,0,0},
					{0,0,0,0,0,0,0,0,0,0,0,0,0},
					{0,0,0,0,0,0,0,0,0,0,0,0,0},
					{0,0,0,1,1,1,1,1,1,1,1,1,1},
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

	void ArrangeBrick()
	{
		//벽돌 배치..
		for (int i = 0; i<BRICK_COLUMN; i++) {
			for (int j = 0; j<BRICK_ROW; j++) {
				if(brickData[i,j] == 0)
				{
					continue;
				}
				//0이아닌경우 블록 배치..

				// 실제 인스턴스 생성..

				GameObject cloneBrick = MonoBehaviour.Instantiate (brick) as GameObject;

				cloneBrick.name = "brick_" + i.ToString() + "_" + j.ToString(); // name을 변경..
				cloneBrick.transform.parent = brickPanel.transform;
				float width = BRICK_WIDTH;
				Vector3 pos = new Vector3();
				pos.x = j * BRICK_WIDTH + 0.5f * BRICK_WIDTH;
				pos.y = GAMEPANEL_HEIGHT - i * BRICK_HEIGHT - 0.5f*BRICK_HEIGHT;
				pos.z = 0;
				cloneBrick.renderer.material.SetColor ("_Color", new Color((((i+j)*11)%64+64)/256f,0,0	));

				//cloneBrick.renderer.material.SetColor ("_Color", Color.red);
				cloneBrick.transform.position = pos;

			}
		}
	}
}
