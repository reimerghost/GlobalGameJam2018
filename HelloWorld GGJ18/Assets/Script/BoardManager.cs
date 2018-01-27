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
	public Count wallCount = new Count(5,9);
	public Count foodCount = new Count(1,5);
	public GameObject exit;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;

	private Transform boardHolder;
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
		boardHolder = new GameObject ("Board").transform;

		for ( int x = -1; x < columns + 1; x++){
			for (int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = floorTiles [Random.Range (0, floorTiles.Length)];

				if (x == -1 || x == columns || y == -1 || y == rows) {
					toInstantiate = outerWallTiles [Random.Range (0, outerWallTiles.Length)];
				}

				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;

				instance.transform.SetParent (boardHolder);
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

	public void SetupScene(int level){
		BoardSetup ();
		InitialiseList ();
		LayoutObjectAtRandom (wallTiles, wallCount.minimun, wallCount.maximun);
		LayoutObjectAtRandom (foodTiles, foodCount.minimun, foodCount.maximun);
		int enemyCout = (int)Mathf.Log (level,2f);
		LayoutObjectAtRandom (enemyTiles, enemyCout, enemyCout);
		Instantiate(exit, new Vector3(columns -1, rows -1, 0F), Quaternion.identity);
	} 

}
