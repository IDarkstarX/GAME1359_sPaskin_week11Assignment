using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    // can't see 2D array in inspector
    public Transform[] roomSpawnersRow0;
    public Transform[] roomSpawnersRow1;
    public Transform[] roomSpawnersRow2;
    public Transform[] roomSpawnersRow3;

    public int[,] roomGrid = new int[4,4];

    public GameObject[] rooms;

    public int testRow = 0;
    public int testColumn = 0;
    public int testType = 0;

    int rngNum;

    // Use this for initialization
    void Start () {

        Debug.Log(roomGrid.Length);

        for (int i = 0; i < 4; i++) {
            Debug.Log("row: "+ i);
            bool hasGoneDown = false;
            for (int j = 0; j < 4; j++) {
                Debug.Log("col: " + j);
                if (i == 0 && j == 0)
                {
                    roomGrid[i,j] = Random.Range(1, 3);
                } else if(roomGrid[i,j] != null) {

                    rngNum = Random.Range(1, 5);
                    if (rngNum != 4)
                    {
                        roomGrid[i, j] = Random.Range(1, 3);
                    }
                    else
                    {
                        rngNum = Random.Range(1, 3);
                        if (rngNum == 1)
                        {
                            roomGrid[i, j] = 2;
                        }
                        else if (rngNum == 2)
                        {
                            roomGrid[i, j] = 4;
                        }

                        hasGoneDown = true;
                    }
                    if(j == 4 && !hasGoneDown)
                    {
                        int[] randomFromSet = new int[] { 2, 4 };
                        int RandomSetIndex = (int)Mathf.Min(randomFromSet.Length - 1, Random.Range(0, randomFromSet.Length));
                        roomGrid[i, j] = RandomSetIndex;
                    }
                }
                Debug.Log(roomGrid[i,j]);
                if (i - 1 != -1)
                {
                    if (roomGrid[i - 1, j] == 2 || roomGrid[i - 1, j] == 4)
                    {
                        rngNum = Random.Range(1, 5);
                        if (rngNum != 4)
                        {
                            roomGrid[i, j] = 3;
                        }
                        else
                        {
                            roomGrid[i, j] = 4;
                        }
                    }
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                AddRoom(i, j, roomGrid[i, j]);
            }
        }

                /*
                AddRoom(i, j, Random.Range(1, 3));
                            Instantiate(rooms[0], new Vector3(-34, 0, -0.02f), transform.rotation);
                roomPicker = Random.Range(1, 3);
                Debug.Log(roomPicker);
                AddRoom(0, 0, roomPicker);
                Instantiate(rooms[0], new Vector3(-34, 0, 0), transform.rotation);

                if(roomPicker == 2) //down left(stop) right
                {
                    roomPicker = Random.Range(3, 5);
                    Debug.Log(roomPicker);
                    AddRoom(1, 0, roomPicker);
                    Instantiate(rooms[0], new Vector3(-34, 0, -34), transform.rotation);

                    if(roomPicker == 4) //down left(stop) right >> down left(stop) right
                    {
                        roomPicker = Random.Range(3, 5);
                        Debug.Log(roomPicker);
                        AddRoom(2, 0, roomPicker);
                        Instantiate(rooms[0], new Vector3(-34, 0, -34), transform.rotation);

                        if (roomPicker == 4) //down left(stop) right >> down left(stop) right >> down left(stop) right
                        {
                            roomPicker = Random.Range(3, 5);
                            Debug.Log(roomPicker);
                            AddRoom(2, 0, roomPicker);
                            Instantiate(rooms[0], new Vector3(-34, 0, -68), transform.rotation);

                            if (roomPicker == 4) //down left(stop) right >> down left(stop) right >> down left(stop) right >> down(stop) left(stop) right
                            {
                                roomPicker = Random.Range(3, 5);
                                Debug.Log(roomPicker);
                                AddRoom(2, 0, roomPicker);
                                Instantiate(rooms[0], new Vector3(-34, 0, -136), transform.rotation);
                                Instantiate(rooms[0], new Vector3(0, 0, -170), transform.rotation);
                            }
                        }
                    }

                } else //left right
                {
                    roomPicker = Random.Range(1, 3);
                    Debug.Log(roomPicker);
                    AddRoom(0, 1, roomPicker);
                }
                */

            }

    // Update is called once per frame
    void Update () {
		
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddRoom(testRow, testColumn, testType);
        }
	}

    public void AddRoom(int row, int column, int roomType)
    {
        Vector3 spawnPos = Vector3.zero;
        // figure out position to spawn at
        switch(row)
        {
            case 0:
                spawnPos = roomSpawnersRow0[column].position;
                break;
            case 1:
                spawnPos = roomSpawnersRow1[column].position;
                break;
            case 2:
                spawnPos = roomSpawnersRow2[column].position;
                break;
            case 3:
                spawnPos = roomSpawnersRow3[column].position;
                break;
        }

        // actually spawn it
        Instantiate(rooms[roomType], spawnPos, transform.rotation);
    }
}
