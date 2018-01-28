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

    /*public GameObject[] floorTiles;
	public GameObject[] wallTiles;
	public GameObject[] foodTiles;
	public GameObject[] enemyTiles;
	public GameObject[] outerWallTiles;
    public GameObject[] salidas;*/

    public GameObject[] pisos;
    public GameObject[] muros;

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
        /*
        GenerarBaseTablero("Uno", 5, 0,1,1);
        GenerarBaseTablero("Dos", -5, 0, 2, 2);
        GenerarBaseTablero("Tres", 5, 10, 3, 3);
        GenerarBaseTablero("Cuatro", -5, 10, 4, 4);
        GenerarBaseTablero("Cinco", 5, 20, 5, 5);
        GenerarBaseTablero("Seis", -5, 20, 6, 6);
        IngresoTablero1();
        IngresoTablero2();*/

        String[] codigoJugador1 = new String[] { "Floor1;Muro1,Muro1,Muro1,Muro1,Muro1,Muro1,Muro1,Muro1", "Floor1;Muro1,Muro1,Muro1,Muro1,Muro1,Muro1,Muro1,Muro1" };
        GeneracionTableroJugador1(codigoJugador1);
        GeneracionTableroJugador2(codigoJugador1);


        GameObject Play1 = GameObject.Find("Player1");
        Vector3 pos2 = new Vector3(7, 3, 0);
        Play1.transform.position = pos2;
        GameObject Play2 = GameObject.Find("Player2");
        Vector3 pos3 = new Vector3(-7, 3, 0);
        Play2.transform.position = pos3;

    }

    void GeneracionTableroJugador1(String[] niveles)
    {
        //Pos en X + 5;
        float x = 5;
        float y = 0;
        //int contadorCol = 0;
        //int contadorFil = 0;
        for (int i = 0; i < niveles.Length; i++)
        {
            //pos dentro de tablero, dentro de nivel
            float temporaly = y;

            Transform tablero = new GameObject("Tablero" + i.ToString()).transform;
            String cadena = niveles[i];
            String[] comandos = cadena.Split(';');
            for (int ii = 0; ii < comandos.Length; ii++)
            {
                String nombreElemento = comandos[ii];
                if (ii == 0)    //es piso
                {
                    GenerarPiso(nombreElemento, tablero, x, y);     //Empieza en 5
                    continue;
                }
                else
                {
                    float temporalx = x;
                    String[] elemento = nombreElemento.Split(',');
                    for (int iii = 0; iii < elemento.Length; iii++)
                    {
                        String unidad = elemento[iii];
                        if (unidad.Contains("Muro"))
                        {
                            GenerarMuro(unidad, tablero, temporalx, temporaly);
                        }
                        temporalx = temporalx + 1.28f;
                    }
                }
                temporaly = temporaly + 1.28f;
            }
            y = y + 12.8f;
        }

    }

    void GeneracionTableroJugador2(String[] niveles)
    {
        //Pos en X + 5;
        float x = -17.8f;
        float y = 0f;
        //int contadorCol = 0;
        //int contadorFil = 0;
        for (int i = 0; i < niveles.Length; i++)
        {
            //pos dentro de tablero, dentro de nivel
            float temporaly = y;

            Transform tablero = new GameObject("Tablero" + i.ToString()).transform;
            String cadena = niveles[i];
            String[] comandos = cadena.Split(';');
            for (int ii = 0; ii < comandos.Length; ii++)
            {
                String nombreElemento = comandos[ii];
                if (ii == 0)    //es piso
                {
                    GenerarPiso(nombreElemento, tablero, x, y);     //Empieza en 5
                    continue;
                }
                else
                {
                    float temporalx = x;
                    String[] elemento = nombreElemento.Split(',');
                    for (int iii = 0; iii < elemento.Length; iii++)
                    {
                        String unidad = elemento[iii];
                        if (unidad.Contains("Muro"))
                        {
                            GenerarMuro(unidad, tablero, temporalx, temporaly);
                        }
                        temporalx = temporalx + 1.28f;
                    }
                }
                temporaly = temporaly + 1.28f;
            }
            y = y + 12.8f;
        }

    }

    void GenerarMuro(String nombreElemento, Transform tablero, float x, float y)
    {
        GameObject muro = null;
        for (int index = 0; index < muros.Length; index++)
        {
            if (muros[index].name.Equals(nombreElemento))
            {
                muro = muros[index];
                index = muros.Length;
            }
        }
        GameObject instance;

        instance = Instantiate(muro, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(tablero);
    }

    void GenerarPiso(String nombreElemento, Transform tablero, float x, float y)
    {
        GameObject piso = null;
        for (int index = 0; index < pisos.Length; index++)
        {
            if (pisos[index].name.Equals(nombreElemento))
            {
                piso = pisos[index];
                index = pisos.Length;
            }
        }
        GameObject instance;

        for (int contadorCol = 0; contadorCol < columns; contadorCol++)
        {
            for (int contadorFil = 0; contadorFil < rows; contadorFil++)
            {

                instance = Instantiate(piso, new Vector3(contadorFil + x + (contadorFil * 0.28f), contadorCol + y + (contadorCol * 0.28f), 0f), Quaternion.identity) as GameObject;
                instance.transform.SetParent(tablero);

            }
        }
    }


    /*
    void IngresoTablero1()
    {
        Transform boardHolder = GameObject.Find("Uno").transform;
        GameObject instance = Instantiate(salidas[0], new Vector3(10, 5, 0f), Quaternion.identity) as GameObject;
        instance.transform.SetParent(boardHolder);
    }

    void IngresoTablero2()
    {
        Transform boardHolder = GameObject.Find("Dos").transform;
        GameObject instance = Instantiate(salidas[1], new Vector3(-10, 5, 0f), Quaternion.identity) as GameObject;
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
    }*/

    public void SetupScene(){
		BoardSetup ();
		InitialiseList ();
	}

}
