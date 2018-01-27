using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {
	[Serializable]
	public class Count{
		public int minimun;
		public int maximun;

		public Count(int min, int max){
			minimun = min;
			maximun = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	//public Count wallCount = new Count(5,9);
	//public Count foodCount = new Count(1,5);
	public GameObject exit;
	public GameObject[] floorTiles;
	/*public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;*/
	public GameObject[] outerWallTiles;


	//private Transform boardHolder;
	private List <Vector3> gridPositions = new List<Vector3>();

	void InitialiseList(){
		gridPositions.Clear();
		for (int x = 1; x < columns - 1; x++) {
			for (int y = 1; y < rows - 1; y++) {
				gridPositions.Add (new Vector3 (x, y, 0f));
			}
		}
	}

	void BoardSetup(){
        //Debug.Log("Hello World2");
        GenerarBaseTablero("Uno", 5, 0,1,1);
        GenerarBaseTablero("Dos", -5, 0, 2, 2);
        GenerarBaseTablero("Tres", 5, 10, 2, 2);
        GenerarBaseTablero("Cuatro", -5, 10, 4, 4);
        GenerarBaseTablero("Cinco", 5, 20, 5, 5);
        GenerarBaseTablero("Seis", -5, 20, 6, 6);
        IngresoTablero1();
        GameObject Play = GameObject.Find("Player");
        Vector3 pos2 = new Vector3(5, 0, 0);
        Play.transform.position = pos2;

    }

    void IngresoTablero1()
    {
        Transform boardHolder = GameObject.Find("Uno").transform;
        GameObject instance = Instantiate(exit, new Vector3(10, 5, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(boardHolder);
    }

    void GenerarBaseTablero(String nombre, int inicioX, int inicioY, int indicePiso, int indiceMuro )
    {
        indicePiso--;
        indiceMuro--;
        Transform boardHolder = new GameObject(nombre).transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[indicePiso];

                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[indiceMuro];
                }

                GameObject instance;

                if (inicioX > 0)
                {
                    instance = Instantiate(toInstantiate, new Vector3(x+inicioX, y + inicioY, 0f), Quaternion.identity) as GameObject;
                }
                else
                {
                    instance = Instantiate(toInstantiate, new Vector3(-x+inicioX, y + inicioY, 0f), Quaternion.identity) as GameObject;
                }
                

                instance.transform.SetParent(boardHolder);
            }
        }
    }

	public void SetupScene(){
		BoardSetup ();
		InitialiseList ();
	}

}
