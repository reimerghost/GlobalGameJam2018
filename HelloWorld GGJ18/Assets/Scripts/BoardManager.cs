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
	//public GameObject exit;
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

        //GenerarTablero1();
        //GenerarTablero2();
        GenerarBaseTablero("Uno", 5, 0,1,1);
        GenerarBaseTablero("Dos", -5, 0, 2, 2);
        GenerarBaseTablero("Tres", 5, 10, 3, 3);
        GenerarBaseTablero("Cuatro", -5, 10, 4, 4);
        GenerarBaseTablero("Cinco", 5, 20, 5, 5);
        GenerarBaseTablero("Seis", -5, 20, 6, 6);
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

    void GenerarTablero2()
    {

        Transform boardHolder = new GameObject("Board1").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {
                GameObject toInstantiate = floorTiles[0];

                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[0];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(x+5, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }

    }

    void GenerarTablero1()
    {

        Transform boardHolder = new GameObject("Board2").transform;

        for (int x = -1; x < columns + 1; x++)
        {
            for (int y = -1; y < rows + 1; y++)
            {             
                GameObject toInstantiate = floorTiles[1];

                if (x == -1 || x == columns || y == -1 || y == rows)
                {
                    toInstantiate = outerWallTiles[1];
                }

                GameObject instance = Instantiate(toInstantiate, new Vector3(-x-5, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
        }

    }

	Vector3 RandomPosition(){
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimun, int maximun){
		int objectCount = Random.Range (minimun, maximun +1);
		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosisiton = RandomPosition ();
			GameObject tileChoice = tileArray [Random.Range (0, tileArray.Length)];
			Instantiate (tileChoice, randomPosisiton, Quaternion.identity);
		}
	}

	public void SetupScene(){
		BoardSetup ();
		InitialiseList ();
		//LayoutObjectAtRandom (wallTiles, wallCount.minimun, wallCount.maximun);
		//LayoutObjectAtRandom (foodTiles, foodCount.minimun, foodCount.maximun);
		//int enemyCout = (int)Mathf.Log (level,2f);
		//LayoutObjectAtRandom (enemyTiles, enemyCout, enemyCout);
		//Instantiate(exit, new Vector3(columns -1, rows -1, 0F), Quaternion.identity);
	} 

}
